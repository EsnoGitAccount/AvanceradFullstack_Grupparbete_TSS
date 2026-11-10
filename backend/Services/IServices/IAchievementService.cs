using Backend.Dto;
using Backend.Model;

namespace Backend.Services.IServices
{
    public interface IAchievementService
    {
        Task<List<AchievementDto>> GetUnachievedAchievementsAsync(List<AchievementDto> achieved);
        Task<List<AchievementDto>> CheckAchievementsAsync(User user, bool hasVisitedMora);
    }
}
