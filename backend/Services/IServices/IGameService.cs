using Backend.Dto;
using System.Net;

namespace Backend.Services.IServices
{
    public interface IGameService
    {
        Task CreateGameAsync(GameDto gameDto);

        Task<IEnumerable<ReusltDto>> GetResultsForDateAsync(DateOnly? date);
    }
}
