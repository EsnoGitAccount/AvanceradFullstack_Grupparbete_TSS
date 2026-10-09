using Backend.Model;

namespace Backend.Repositories.IRepositories
{
    public interface IGameRepository
    {
        Task<bool> CreateGameAsync(Game game);
    }
}
