using Backend.Dto;
using Backend.Model;
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

        public async Task<List<AchievementDto>> CheckAchievementsAsync(User user, bool hasVisitedMora)
        {
            var achievedIds = user.Achievements.Select(a => a.AchievementId).ToHashSet();

            var candidates = await _achievementRepository.GetUnachievedAchievementsAsync(achievedIds.ToList());

            var newAchievements = candidates
                .Where(a => IsUnlocked(a, user, hasVisitedMora))
                .ToList();

            foreach (var achievement in newAchievements)
            {
                user.Achievements.Add(achievement);
            }

            return newAchievements
                .Select(a => new AchievementDto(a))
                .ToList();
        }

        private static bool IsUnlocked(Achievement achievement, User user, bool hasVisitedMora)
        {
            return achievement.AchievementId switch
            {
                // Streak
                1 => user.LongestStreak >= 3,
                2 => user.LongestStreak >= 7,
                3 => user.LongestStreak >= 14,
                4 => user.LongestStreak >= 31,
                5 => user.LongestStreak >= 50,
                6 => user.LongestStreak >= 80,
                7 => user.LongestStreak >= 100,
                8 => user.LongestStreak >= 140,
                9 => user.LongestStreak >= 180,
                10 => user.LongestStreak >= 250,
                11 => user.LongestStreak >= 307,
                12 => user.LongestStreak >= 365,

                // Registered user
                13 => true,

                // Total score
                14 => user.TotalScore >= 100,
                15 => user.TotalScore >= 500,
                16 => user.TotalScore >= 1000,

                // Visited Mora
                17 => hasVisitedMora,

                _ => false
            };
        }
    }
}
