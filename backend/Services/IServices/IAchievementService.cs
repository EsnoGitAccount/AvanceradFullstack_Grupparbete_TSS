using Backend.Dto;

namespace Backend.Services.IServices
{
    public interface IAchievementService
    {
        Task<List<AchievementDto>> GetUnachievedAchievementsAsync(List<AchievementDto> achieved);
    }
}
