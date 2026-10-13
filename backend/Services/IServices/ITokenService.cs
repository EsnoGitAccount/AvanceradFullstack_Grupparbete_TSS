using Backend.Model;

namespace Backend.Services.IServices
{
    public interface ITokenService
    {
        string CreateAccessToken(
            User user,
            IEnumerable<string> roles,
            DateTimeOffset expiresAt);

        string CreateRefreshToken();

        string HashRefreshToken(string refreshToken);
    }
}