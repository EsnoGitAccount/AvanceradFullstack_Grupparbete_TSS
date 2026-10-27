using Backend.Dto;
using System.Net;

namespace Backend.Services.IServices
{
    public interface IGameService
    {
        Task CreateGameAsync(GameDto gameDto);
        Task<IEnumerable<GameResultDto>> GetGameResultsAsync();
        Task DeleteGameResultAsync(int gameId);
        Task<IEnumerable<ResultDto>> GetResultsForDateAsync(DateOnly? date);
    }
}
