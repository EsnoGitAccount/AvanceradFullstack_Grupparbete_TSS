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
    }
}
