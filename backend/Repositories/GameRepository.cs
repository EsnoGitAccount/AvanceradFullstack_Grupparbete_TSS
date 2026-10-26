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
        public async Task<int> CreateGameAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();

            return game.GameId;
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
        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _context.Games
                .AsNoTracking()
                .Include(g => g.User)
                .ToListAsync();
        }
    }
}
