using Backend.Model;

namespace Backend.Repositories.IRepositories
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken refreshToken);

        Task<RefreshToken?> GetByTokenHashAsync(string tokenHash);

        Task RevokeSessionAsync(Guid sessionId);

        Task<bool> RotateAsync(RefreshToken currentToken, RefreshToken replacementToken);
    }
}