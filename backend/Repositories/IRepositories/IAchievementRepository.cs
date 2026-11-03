using Backend.Model;

namespace Backend.Repositories.IRepositories
{
    public interface IAchievementRepository
    {
        Task<List<Achievement>> GetUnachievedAchievementsAsync(List<int> achievedIds);
    }
}
