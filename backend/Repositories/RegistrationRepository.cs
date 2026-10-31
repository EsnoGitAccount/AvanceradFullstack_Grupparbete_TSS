using Backend.Data;
using Backend.Dto;
using Backend.Exceptions;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Backend.Repositories
{
	/// <summary>
	///
	/// Registration consists of three steps:
	/// 1. Create the user using ASP.NET Core Identity.
	/// 2. Assign the default "User" role.
	/// 3. Store the hashed refresh token in the database.
	///
	/// All steps must succeed before the transaction is committed.
	/// If any step fails before Commit, the transaction is rolled back, preventing
	/// partially registered users from being saved in the database.
	///
	/// ExecutionStrategy automatically retries the entire operation
	/// when transient database errors occur.
	///
	/// Each retry uses a new dependency injection scope to ensure
	/// that DbContext and UserManager are fresh and share the same
	/// database transaction.
	/// </summary>

	public class RegistrationRepository : IRegistrationRepository
	{
		private readonly WhereAreWeDbContext _context;
		private readonly IServiceScopeFactory _scopeFactory;


		public RegistrationRepository(WhereAreWeDbContext context,IServiceScopeFactory scopeFactory)
		{
			_context = context;
			_scopeFactory = scopeFactory;

		}
		public async Task<AuthSessionDto> RegisterAsync(RegisterDto registerDto, Func<User,IList<string>, Task<(AuthSessionDto sessionDto, string refreshTokenHash)>> createSession)
		{

			var sessionId = Guid.NewGuid();
			var strategy = _context.Database.CreateExecutionStrategy();

			return await strategy.ExecuteAsync(async () =>
			{
				await using var scope = _scopeFactory.CreateAsyncScope();

				var context = scope.ServiceProvider.GetRequiredService<WhereAreWeDbContext>();

				var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

				await using var transaction = await context.Database.BeginTransactionAsync();

				var user = new User
				{
					UserName = registerDto.UserName,
					Email = registerDto.Email
				};

				var result = await userManager.CreateAsync(user, registerDto.Password);

				if (!result.Succeeded)
				{
					var errors = string.Join("; ", result.Errors.Select(error => error.Description));

					throw new AppValidationException(errors);
				}

				
				var roleResult = await userManager.AddToRoleAsync(user, "User");

				if (!roleResult.Succeeded)
				{
					var errors = string.Join("; ", roleResult.Errors.Select(error => error.Description));

					throw new AppValidationException(errors);
				}

				var userRoles = await userManager.GetRolesAsync(user);

				var (sessionDto, refreshTokenHash) = await createSession(user,userRoles);

				var refreshToken = new RefreshToken
				{
					UserId = user.Id,
					SessionId = sessionId,
					TokenHash = refreshTokenHash,
					ExpiresAt = sessionDto.RefreshTokenExpiresAt
				};

				await context.RefreshTokens.AddAsync(refreshToken);
				await context.SaveChangesAsync();

				await transaction.CommitAsync();

				return sessionDto;
			});
		}
	}
}
