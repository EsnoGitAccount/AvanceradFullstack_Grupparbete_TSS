using Backend.Data;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class AchievementRepository : IAchievementRepository
    {
        private readonly WhereAreWeDbContext _context;

        public AchievementRepository(WhereAreWeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Achievement>> GetUnachievedAchievementsAsync(List<int> achievedIds)
        {
            return await _context.Achievements
                .Where(a => !achievedIds.Contains(a.AchievementId))
                .ToListAsync();
        }
    }
}
