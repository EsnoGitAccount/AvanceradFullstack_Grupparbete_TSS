using Backend.Dto;

namespace Backend.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<AdminUserDto>> GetRegularUsersAsync();
        Task ArchiveUserAsync(int userId);
        Task RestoreUserAsync(int userId);
    }
}
