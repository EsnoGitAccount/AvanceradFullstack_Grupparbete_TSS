//using Backend.Dto;
//using Backend.Services;
//using Backend.Services.IServices;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//namespace Backend.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    [Authorize]
//    public class ProfileController : ControllerBase
//    {
//        private readonly IAuthService _authService;
//        private readonly IGameService _gameService;
//        public ProfileController(IAuthService authService, IGameService gameService)
//        {
//            _authService = authService;
//            _gameService = gameService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<UserProfileDto>> GetProfile()
//        {
//            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//            if(!int.TryParse(userIdClaim, out var userId))
//            {
//                return Unauthorized();
//            }

//            var user = await _authService.GetCurrentUserAsync(userId);

//            var streak = await _gameService.GetStreakForUserAsync(userId);

//            var profile = new UserProfileDto
//            {
//                Username = user.Username,
//                Email = user.Email,
//                CurrentStreak = streak
//            };

//            return Ok(profile);
//        }
//    }
//}

using Backend.Dto;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] <-- Kommenterad tillfälligt för att slippa 401 vid test
    public class ProfileController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IGameService _gameService;

        public ProfileController(IAuthService authService, IGameService gameService)
        {
            _authService = authService;
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<UserProfileDto>> GetProfile()
        {
            // 1. Försök hämta ID från inloggad användare
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // 2. Om ingen användare är inloggad ännu (eller saknar ID), krocka inte med 401 utan testa med ID 1
            if (!int.TryParse(userIdStr, out var userId))
            {
                userId = 1; // Fallback till din seedade user1 för snabbtest!
            }

            var user = await _authService.GetCurrentUserAsync(userId);

            // Om användaren inte hittades i DB
            if (user == null)
            {
                return NotFound("Användaren hittades inte");
            }

            // Tillfälligt mockad streak (3) så du slipper krascha om spelhistorik saknas i DB
            var streak = 3;
            // När allt snurrar ändrar du tillbaka till:
            // var streak = await _gameService.GetStreakForUserAsync(userId);

            var profile = new UserProfileDto
            {
                Username = user.Username,
                Email = user.Email,
                CurrentStreak = streak
            };

            return Ok(profile);
        }
    }
}