using Backend.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public static class AchievementSeed
    {
        private static readonly IReadOnlyDictionary<string, int[]> UserAchievements =
            new Dictionary<string, int[]>
            {
                ["user1"] = [1, 13],
                ["user2"] = [1, 2, 13]
            };

        public static async Task SeedAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var dbContext = services.GetRequiredService<WhereAreWeDbContext>();

            var achievementIds = UserAchievements.Values
                .SelectMany(ids => ids)
                .Distinct()
                .ToArray();

            var achievements = await dbContext.Achievements
                .Where(achievement => achievementIds.Contains(achievement.AchievementId))
                .ToDictionaryAsync(achievement => achievement.AchievementId);

            var missingAchievementIds = achievementIds.Except(achievements.Keys).ToArray();

            if (missingAchievementIds.Length > 0)
            {
                throw new InvalidOperationException(
                    $"The following achievements are missing from the database: {string.Join(", ", missingAchievementIds)}.");
            }

            foreach (var userAchievement in UserAchievements)
            {
                var user = await userManager.FindByNameAsync(userAchievement.Key);

                if (user == null)
                {
                    continue;
                }

                await dbContext.Entry(user)
                    .Collection(currentUser => currentUser.Achievements)
                    .LoadAsync();

                foreach (var achievementId in userAchievement.Value)
                {
                    if (!user.Achievements.Any(achievement => achievement.AchievementId == achievementId))
                    {
                        user.Achievements.Add(achievements[achievementId]);
                    }
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
