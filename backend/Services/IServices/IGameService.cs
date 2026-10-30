using Backend.Dto;

namespace Backend.Services.IServices
{
    public interface IGameService
    {
        Task<int> CreateGameAsync(GameDto gameDto);
        Task<IEnumerable<GameResultDto>> GetGameResultsAsync();
        Task DeleteGameResultAsync(int gameId);
        Task<int> GetStreakForUserAsync(int userId);
        Task<IEnumerable<ResultDto>> GetResultsForDateAsync(DateOnly? date, int? currentUserId);
        bool GuestUserHasPlayedToday(string? cookie);
        string CreatedGuestPlayedCookie();
    }
}
