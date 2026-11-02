using Backend.Dto;
using Backend.Model;

namespace Backend.Repositories.IRepositories
{
	public interface IRegistrationRepository
	{
		/// <summary>
		/// The createSession parameter is a Func delegate (callback)
		/// provided by AuthService.
		/// 
		/// It receives the newly created User and their assigned roles,
		/// then returns an AuthSessionDto and a hashed refresh token.
		/// 
		/// This allows AuthService to handle token generation while
		/// RegistrationRepository handles database operations and transactions.
		/// 
		/// The callback is executed after the user and role are created,
		/// but before the transaction is committed.
		/// </summary>

		Task<AuthSessionDto> RegisterAsync(RegisterDto registerDto,
			Func<User, IList<string>,Task<(AuthSessionDto sessionDto, string refreshTokenHash)>> createSession);
	}
}
