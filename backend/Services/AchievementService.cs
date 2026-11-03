using Backend.Dto;
using Backend.Repositories.IRepositories;
using Backend.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository _achievementRepository;

        public AchievementService(IAchievementRepository achievementRepository)
        {
            _achievementRepository = achievementRepository;
        }
        public async Task<List<AchievementDto>> GetUnachievedAchievementsAsync(List<AchievementDto> achieved)
        {
            var achievedIds = achieved.Select(a => a.AchievementId).ToList();
            var unachieved = await _achievementRepository.GetUnachievedAchievementsAsync(achievedIds);
            return unachieved.Select(a => new AchievementDto(a)).ToList();
        }
    }
}
