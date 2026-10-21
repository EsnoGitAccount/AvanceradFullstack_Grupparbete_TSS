using Backend.Model;

namespace Backend.Repositories.IRepositories
{
    public interface IGameRepository
    {
        Task<bool> CreateGameAsync(Game game);

        Task <IEnumerable<Game>> GetGamesForDateAsync(DateOnly date);

        Task <IEnumerable<Game>> GetGamesForUserAsync(int userId);

        Task <IEnumerable<Game>> GetAllGamesAsync();
    }
}
