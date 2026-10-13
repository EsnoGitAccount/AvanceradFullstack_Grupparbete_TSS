using Backend.Model;

namespace Backend.Repositories.IRepositories
{
    public interface IDailyChallengeRepository
    {
        Task<DailyChallange?> GetChallengeForDate(DateOnly date);

        Task<bool> CreateTodaysDailyChallenge(int cityId);
    }
}
