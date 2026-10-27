using Backend.Model;

namespace Backend.Repositories.IRepositories
{
    public interface IGameRepository
    {
        Task<Game> CreateGameAsync(Game game);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<Game?> GetGameByIdAsync(int gameId);
        Task<bool> DeleteGameAsync(Game game);
        Task<IEnumerable<Game>> GetGamesForDateAsync(DateOnly date);
        Task<IEnumerable<Game>> GetGamesForUserAsync(int userId);
    }
}
