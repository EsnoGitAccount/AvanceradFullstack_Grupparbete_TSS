using Backend.Dto;
using Backend.Exceptions;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Backend.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly ITokenService _tokenService;
		private readonly IRefreshTokenRepository _refreshTokenRepository;
		private readonly int _accessTokenMinutes;
		private readonly int _refreshTokenDays;
		private readonly IRegistrationRepository _registrationRepository;

		public AuthService(
			UserManager<User> userManager, SignInManager<User> signInManager,
			ITokenService tokenService,
			IRefreshTokenRepository refreshTokenRepository,
			IConfiguration configuration,
			IRegistrationRepository registrationRepository)

		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenService = tokenService;
			_refreshTokenRepository = refreshTokenRepository;
			_registrationRepository = registrationRepository;

			_accessTokenMinutes = configuration.GetValue<int>("Jwt:AccessTokenMinutes");

			_refreshTokenDays = configuration.GetValue<int>("Jwt:RefreshTokenDays");

			if (_accessTokenMinutes <= 0 || _refreshTokenDays <= 0)
			{
				throw new InvalidOperationException("JWT token lifetimes must be greater than zero.");
			}
		}

		public async Task<AuthSessionDto> LoginAsync(LoginDto loginDto)
		{
			var user = await _userManager.FindByNameAsync(loginDto.Username) ??
				throw new UnauthorizedException("Invalid username or password.");

			if (user.IsArchived)
			{
				throw new UnauthorizedException("Invalid username or password.");
			}

			var result = await _signInManager.CheckPasswordSignInAsync(
				user,
				loginDto.Password,
				lockoutOnFailure: true);

			if (!result.Succeeded)
			{
				throw new UnauthorizedException("Invalid username or password.");
			}

			var session = await CreateSessionAsync(
				user,
				DateTimeOffset.UtcNow.AddDays(_refreshTokenDays));

			await _refreshTokenRepository.AddRefreshTokenAsync(new RefreshToken
			{
				UserId = user.Id,
				SessionId = Guid.NewGuid(),
				TokenHash = _tokenService.HashRefreshToken(session.RefreshToken),
				ExpiresAt = session.RefreshTokenExpiresAt
			});

			return session;
		}

		public async Task<AuthSessionDto> RefreshAsync(string refreshToken)
		{
			if (string.IsNullOrWhiteSpace(refreshToken))
			{
				throw new UnauthorizedException("Invalid refresh token.");
			}

			var tokenHash = _tokenService.HashRefreshToken(refreshToken);

			var currentToken = await _refreshTokenRepository.GetRefreshTokenByHashAsync(tokenHash) ??
				throw new UnauthorizedException("Invalid refresh token.");

			if (currentToken.RevokedAt != null)
			{
				await _refreshTokenRepository.RevokeSessionAsync(currentToken.SessionId);

				throw new UnauthorizedException("Invalid refresh token.");
			}

			if (currentToken.ExpiresAt <= DateTimeOffset.UtcNow)
			{
				throw new UnauthorizedException("Refresh token has expired.");
			}

			var user = await _userManager.FindByIdAsync(currentToken.UserId.ToString(CultureInfo.InvariantCulture));

			if (user == null || user.IsArchived || !await _signInManager.CanSignInAsync(user) || await _userManager.IsLockedOutAsync(user))
			{
				await _refreshTokenRepository.RevokeSessionAsync(currentToken.SessionId);

				throw new UnauthorizedException("Session is no longer valid.");
			}

			var session = await CreateSessionAsync(user, currentToken.ExpiresAt);

			var replacementToken = new RefreshToken
			{
				UserId = user.Id,
				SessionId = currentToken.SessionId,
				TokenHash = _tokenService.HashRefreshToken(session.RefreshToken),
				ExpiresAt = session.RefreshTokenExpiresAt
			};

			var rotated = await _refreshTokenRepository.RotateRefreshTokenAsync(currentToken, replacementToken);

			if (!rotated)
			{
				await _refreshTokenRepository.RevokeSessionAsync(currentToken.SessionId);

				throw new UnauthorizedException("Session is no longer valid.");
			}

			return session;
		}

		public async Task LogoutAsync(string? refreshToken)
		{
			if (string.IsNullOrWhiteSpace(refreshToken))
			{
				return;
			}

			var tokenHash = _tokenService.HashRefreshToken(refreshToken);

			var storedToken = await _refreshTokenRepository.GetRefreshTokenByHashAsync(tokenHash);

			if (storedToken != null)
			{
				await _refreshTokenRepository.RevokeSessionAsync(storedToken.SessionId);
			}
		}

        public async Task<UserDto> GetCurrentUserAsync(int userId)
        {
            var user = await _userManager.Users
                .Include(u => u.Achievements)
                .FirstOrDefaultAsync(u => u.Id == userId)
                ?? throw new UnauthorizedException("User was not found.");

			if (user.IsArchived)
			{
				throw new UnauthorizedException("Session is no longer valid.");
			}

			var userRoles = await _userManager.GetRolesAsync(user);
			return new UserDto(user, userRoles);
		}

		public async Task<AuthSessionDto> RegisterAsync(RegisterDto registerDto)
		{
			var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);

			if (existingUser is not null)
			{
				throw new ConflictException("User already exists.");
			}

			var existingUserName = await _userManager.FindByNameAsync(registerDto.UserName);


			if (existingUserName is not null)
			{
				throw new ConflictException("Username already exists.");
			}

			// Pass a callback to the repository to create the session and hash the refresh token.
			// The repository handles the database transaction and returns the created session.
			return await _registrationRepository.RegisterAsync(registerDto, async (user, userRoles) =>
			{
				var session = await CreateSessionAsync(user, DateTimeOffset.UtcNow.AddDays(_refreshTokenDays), userRoles);

				var refreshTokenHash = _tokenService.HashRefreshToken(session.RefreshToken);

				return (session, refreshTokenHash);
			});

		}


		// Used when roles need to be retrieved from UserManager.
		private async Task<AuthSessionDto> CreateSessionAsync(User user, DateTimeOffset refreshTokenExpiresAt)
		{
			var userRoles = await _userManager.GetRolesAsync(user);

			return await CreateSessionAsync(user, refreshTokenExpiresAt, userRoles);
		}

		// Uses already retrieved roles to avoid accessing UserManager
		// from a different DI scope during registration.
		private Task<AuthSessionDto> CreateSessionAsync(User user, DateTimeOffset refreshTokenExpiresAt, IList<string> userRoles)
		{
			var userDto = new UserDto(user, userRoles);

			var accessTokenExpiresAt = DateTimeOffset.UtcNow.AddMinutes(_accessTokenMinutes);

			return Task.FromResult(new AuthSessionDto
			{
				User = userDto,
				AccessToken = _tokenService.CreateAccessToken(user, userDto.Roles, accessTokenExpiresAt),
				RefreshToken = _tokenService.CreateRefreshToken(),
				AccessTokenExpiresAt = accessTokenExpiresAt,
				RefreshTokenExpiresAt = refreshTokenExpiresAt
			});
		}

	}
}
