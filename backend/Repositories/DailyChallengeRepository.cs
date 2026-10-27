using Backend.Data;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class DailyChallengeRepository : IDailyChallengeRepository
    {
        private readonly WhereAreWeDbContext _context;

        public DailyChallengeRepository(WhereAreWeDbContext context)
        {
            _context = context;
        }

        public async Task<DailyChallange?> GetChallengeForDate(DateOnly date)
        {
            var challenge = await _context.DailyChallanges
                .Include(dc => dc.City)
                    .ThenInclude(city => city.Clues)
                .Include(dc => dc.City)
                    .ThenInclude(city => city.Questions)
                        .ThenInclude(question => question.Options)
                .FirstOrDefaultAsync(c => c.ChallangeDate == date);

            return challenge;
        }

        public async Task<bool> CreateDailyChallenge(DateOnly date, int cityId)
        {
            var newChallenge = new DailyChallange
            {
                ChallangeDate = date,
                CityId = cityId
            };

            await _context.DailyChallanges.AddAsync(newChallenge);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<DailyChallange?> GetLastChallenge()
        {
            var lastChallenge = await _context.DailyChallanges
                .OrderByDescending(c => c.ChallangeDate)
                .FirstOrDefaultAsync();
            return lastChallenge;
        }
    }
}
