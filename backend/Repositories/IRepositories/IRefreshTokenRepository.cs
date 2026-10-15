using Backend.Model;

namespace Backend.Repositories.IRepositories
{
    public interface IRefreshTokenRepository
    {
        Task AddRefreshTokenAsync(RefreshToken refreshToken);

        Task<RefreshToken?> GetRefreshTokenByHashAsync(string tokenHash);

        Task RevokeSessionAsync(Guid sessionId);

        Task<bool> RotateRefreshTokenAsync(RefreshToken currentToken, RefreshToken replacementToken);
    }
}
