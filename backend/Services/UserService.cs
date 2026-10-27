using Backend.Dto;
using Backend.Exceptions;
using Backend.Model;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<AdminUserDto>>
            GetRegularUsersAsync()
        {
            var users = await _userManager
                .GetUsersInRoleAsync("User");

            return users
                .OrderBy(user => user.UserName)
                .Select(user => new AdminUserDto
                {
                    UserId = user.Id,
                    Username = user.UserName ?? string.Empty,
                    Email = user.Email ?? string.Empty,
                    IsArchived = user.IsArchived
                })
                .ToList();
        }

        public async Task ArchiveUserAsync(int userId)
        {
            var user = await GetRegularUserAsync(userId);

            if (user.IsArchived)
            {
                return;
            }

            user.IsArchived = true;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to archive user");
            }
        }

        public async Task RestoreUserAsync(int userId)
        {
            var user = await GetRegularUserAsync(userId);

            if (!user.IsArchived)
            {
                return;
            }

            user.IsArchived = false;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to restore user");
            }
        }

        private async Task<User> GetRegularUserAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(
                userId.ToString(CultureInfo.InvariantCulture)) ??
                throw new NotFoundException("User not found");

            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                throw new ConflictException("Administrator accounts cannot be archived or restored");
            }

            return user;
        }
    }
}
