using Backend.Model;

namespace Backend.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int userId);

        Task<bool> UpdateUserStreakAsync(User user, int streak);
    }
}
