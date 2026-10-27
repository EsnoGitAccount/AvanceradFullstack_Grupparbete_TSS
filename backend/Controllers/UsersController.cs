using Backend.Dto;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<AdminUserDto>>>
            GetRegularUsers()
        {
            var users = await _userService.GetRegularUsersAsync();

            return Ok(users);
        }

        [HttpPost("admin/{userId:int}/archive")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveUser(int userId)
        {
            await _userService.ArchiveUserAsync(userId);

            return Ok();
        }

        [HttpPost("admin/{userId:int}/restore")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreUser(int userId)
        {
            await _userService.RestoreUserAsync(userId);

            return Ok();
        }

    }
}
