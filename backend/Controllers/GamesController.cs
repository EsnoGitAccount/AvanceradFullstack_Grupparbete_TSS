using Backend.Dto;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.DataProtection;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IDataProtector _guestCookieProtector;

        public GamesController(IGameService gameService, IDataProtectionProvider protectionProvider)
        {
            _gameService = gameService;
            _guestCookieProtector = protectionProvider.CreateProtector("GuestDailyGameLimit");
        }

        [HttpPost]
        public async Task<IActionResult> PostGame([FromBody] GameDto gameDto)
        {
            var now = DateTimeOffset.Now;
            var today = now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            gameDto.UserId = null;

            if (User.Identity?.IsAuthenticated == true && int.TryParse
                (User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId))
            {
                gameDto.UserId = userId;
                gameDto.UserName = User.Identity.Name;
            }

            gameDto.IsGuest = !gameDto.UserId.HasValue;

            if (gameDto.IsGuest && _gameService.GuestUserHasPlayedToday(Request.Cookies["GuestDailyGameLimit"]))
            {
                return Problem(statusCode: StatusCodes.Status409Conflict, detail: "Guest users can only play once per day.");
            }

            var gameId = await _gameService.CreateGameAsync(gameDto);

            if (gameDto.IsGuest)
            {
                Response.Cookies.Append("GuestDailyGameLimit", _gameService.CreatedGuestPlayedCookie(), new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    Path = "/",
                    Expires = new DateTimeOffset(now.UtcDateTime.Date.AddDays(1), TimeSpan.Zero)
                });
            }

            return Ok(new
            {
                Message = "Game data received successfully.",
                gameId = gameId,
                IsGuest = gameDto.IsGuest
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetGamesForDate([FromQuery] DateOnly? date)
        {
            var games = await _gameService.GetResultsForDateAsync(date);

            return Ok(games);
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetGameResults()
        {
            var results = await _gameService.GetGameResultsAsync();

            return Ok(results);
        }

        [HttpDelete("admin/{gameId:int}")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGameResult(int gameId)
        {
            await _gameService.DeleteGameResultAsync(gameId);

            return NoContent();
        }
    }
}
