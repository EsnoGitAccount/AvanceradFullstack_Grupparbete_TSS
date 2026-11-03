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

        private readonly IAchievementService _achievementService;
        public ProfileController(IAuthService authService, ILeaderboardService leaderboardService, IAchievementService achievementService   )
        {
            _authService = authService;
            _leaderboardService = leaderboardService;
            _achievementService = achievementService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserProfileDto>> GetProfile()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized();
            }

            var user = await _authService.GetCurrentUserAsync(userId);
            var stats = await _leaderboardService.GetPlayerStatsAsync(userId);

            var profile = new UserProfileDto
            {
                Username = user.Username,
                CurrentStreak = stats?.Streak ?? 0,
                DailyScore = stats?.DailyScore,
                AllTimeScore = stats?.AllTimeScore ?? 0,
                Achievements = user.Achievements,
                UnachievedAchievements = await _achievementService.GetUnachievedAchievementsAsync(user.Achievements)
            };

            return Ok(profile);
        }
    }
}