using Backend.Dto;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILeaderboardService _leaderboardService;
        public ProfileController(IAuthService authService, ILeaderboardService leaderboardService)
        {
            _authService = authService;
            _leaderboardService = leaderboardService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserProfileDto>> GetProfile()
        {
            var userIdClaim = User.FindFirstValue("sub")
               ?? User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized();
            }

            var user = await _authService.GetCurrentUserAsync(userId);
            var stats = await _leaderboardService.GetPlayerStatsAsync(userId);

            var profile = new UserProfileDto
            {
                Username = user.Username,
                Email = user.Email,
                CurrentStreak = stats?.Streak ?? 0,
                DailyScore = stats?.DailyScore,
                AllTimeScore = stats?.AllTimeScore ?? 0,
                Achievements = user.Achievements
            };

            return Ok(profile);
        }
    }
}