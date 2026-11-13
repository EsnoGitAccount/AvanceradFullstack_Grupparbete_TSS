using Backend.Dto;
using Backend.Exceptions;
using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ICookieService _cookieService;
        public AccountController(UserManager<User> userManager, ICookieService cookieService)
        {
            _userManager = userManager;
            _cookieService = cookieService;
        }

        [HttpPatch("username")]
        public async Task<IActionResult> ChangeUsername(ChangeUsernameDto request)
        {
            var user = await GetCurrentUserAsync();

            var existingUser = await _userManager.FindByNameAsync(request.NewUsername);

            if (existingUser != null && existingUser.Id != user.Id)
            {
                throw new ConflictException("Username already exists.");
            }

            var result = await _userManager.SetUserNameAsync(user, request.NewUsername);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }

        [HttpPatch("password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto request)
        {
            var user = await GetCurrentUserAsync();

            var result = await _userManager.ChangePasswordAsync
            (
                user,
                request.CurrentPassword,
                request.NewPassword
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount()
        {
            var user = await GetCurrentUserAsync();

            user.IsArchived = true;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            _cookieService.DeleteAuthenticationCookie(Response);

            return NoContent();
        }

        private async Task<User> GetCurrentUserAsync()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdClaim, out var userId))
            {
                throw new UnauthorizedException("Invalid authenticated user.");
            }

            var user = await _userManager.FindByIdAsync(userIdClaim!);

            if (user == null || user.IsArchived)
            {
                throw new UnauthorizedException("User was not found.");
            }

            return user;
        }
    }
}