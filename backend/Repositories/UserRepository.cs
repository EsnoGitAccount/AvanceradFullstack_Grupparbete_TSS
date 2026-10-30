using Backend.Data;
using Backend.Model;
using Backend.Repositories.IRepositories;

namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WhereAreWeDbContext _context;

        public UserRepository(WhereAreWeDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<bool> UpdateUserStreakAsync(User user, int streak)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.CurrentStreak = streak;

            if (streak > user.LongestStreak)
            {
                user.LongestStreak = streak;
            }

            _context.Users.Update(user);
            
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
