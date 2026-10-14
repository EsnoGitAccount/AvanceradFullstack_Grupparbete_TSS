using Backend.Data;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly WhereAreWeDbContext _context;

        public RefreshTokenRepository(WhereAreWeDbContext context)
        {
            _context = context;
        }

        // Add a new refresh token to the database
        public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Add(refreshToken);

            await _context.SaveChangesAsync();
        }

        // Get a refresh token by its token hash
        public async Task<RefreshToken?> GetRefreshTokenByHashAsync(string tokenHash)
        {
            return await _context.RefreshTokens
                .AsNoTracking()
                .SingleOrDefaultAsync(rt => rt.TokenHash == tokenHash);
        }

        // Revoke all refresh tokens associated with a specific session
        public async Task RevokeSessionAsync(Guid sessionId)
        {
            DateTimeOffset? revokedAt = DateTimeOffset.UtcNow;

            await _context.RefreshTokens
                .Where(rt =>
                    rt.SessionId == sessionId &&
                    rt.RevokedAt == null)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(rt => rt.RevokedAt, revokedAt));
        }

        // Rotate the current refresh token with a replacement token
        public async Task<bool> RotateRefreshTokenAsync(RefreshToken currentToken, RefreshToken replacementToken)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();

                // Check if the current token is still valid and not already revoked
                var now = DateTimeOffset.UtcNow;
                DateTimeOffset? revokedAt = now;

                // Revoke the current refresh token if it is still valid and not already revoked
                var updateRows = await _context.RefreshTokens
                    .Where(rt =>
                        rt.RefreshTokenId == currentToken.RefreshTokenId &&
                        rt.TokenHash == currentToken.TokenHash &&
                        rt.RevokedAt == null &&
                        rt.ExpiresAt > now)
                            .ExecuteUpdateAsync(setters => setters
                                .SetProperty(rt => rt.RevokedAt, revokedAt));

                if (updateRows != 1)
                {
                    return false;
                }

                // Create a new refresh token with the same UserId and SessionId as the current token
                var nextToken = new RefreshToken
                {
                    UserId = currentToken.UserId,
                    SessionId = currentToken.SessionId,
                    TokenHash = replacementToken.TokenHash,
                    ExpiresAt = replacementToken.ExpiresAt,
                };

                // Add the new refresh token to the database
                try
                {
                    _context.RefreshTokens.Add(nextToken);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return true;

                }

                finally
                {
                    _context.Entry(nextToken).State = EntityState.Detached;
                }
            });
        }
    }
}
