using Backend.Data;
using Backend.Model;
using Backend.Repositories.IRepositories;

namespace Backend.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly WhereAreWeDbContext _context;

        public GameRepository(WhereAreWeDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateGameAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
