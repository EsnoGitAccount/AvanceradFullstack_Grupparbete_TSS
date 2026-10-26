using Backend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/leaderboard")]
    public class LeaderboardController(ILeaderboardService leaderboardService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetLeaderboard([FromQuery] int? gameId)
        {
            int? currentUser = null;

            if (User.Identity?.IsAuthenticated == true && int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                currentUser = userId;
            }

            var results = await leaderboardService.GetAsync(currentUser, gameId);

            return Ok(results);
        }
    }
}
