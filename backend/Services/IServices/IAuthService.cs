using Backend.Dto;

namespace Backend.Services.IServices
{
    public interface IAuthService
    {
        // Check credentials and return a session.
        Task<AuthSessionDto> LoginAsync(LoginDto loginDto);

        // Validate and rotate the refresh token, then issue a new access token.
        Task<AuthSessionDto> RefreshAsync(string refreshToken);

        // Revoke the supplied refresh token, effectively logging the user out.
        Task LogoutAsync(string? refreshToken);

        // Load user information and roles.
        Task<UserDto> GetCurrentUserAsync(int userId);

        Task<AuthSessionDto> RegisterAsync(RegisterDto registerDto);
    }
}