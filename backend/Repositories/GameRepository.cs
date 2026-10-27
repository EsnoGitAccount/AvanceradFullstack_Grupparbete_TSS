using Backend.Data;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly WhereAreWeDbContext _context;

        public GameRepository(WhereAreWeDbContext context)
        {
            _context = context;
        }
        public async Task<Game> CreateGameAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            return game;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _context.Games
                .AsNoTracking()
                .Include(game => game.User)
                .Include(game => game.DailyChallange)
                .ThenInclude(challenge => challenge.City)
                .OrderByDescending(game => game.CompletedAt)
                .ThenByDescending(game => game.GameId)
                .ToListAsync();
        }
        public async Task<Game?> GetGameByIdAsync(int gameId)
        {
            return await _context.Games
                .FirstOrDefaultAsync(game => game.GameId == gameId);
        }
        public async Task<bool> DeleteGameAsync(Game game)
        {
            _context.Games.Remove(game);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Game>> GetGamesForDateAsync(DateOnly date)
        {
            return await _context.Games.Where(g => g.CompletedAt == date).ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetGamesForUserAsync(int userId)
        {
            return await _context.Games
                .Where(g => g.UserId == userId)
                .ToListAsync();
        }
    }
}
