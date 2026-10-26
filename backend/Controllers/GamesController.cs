using Backend.Dto;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> PostGame([FromBody] GameDto gameDto)
        {
            gameDto.UserId = null;

            if (User.Identity?.IsAuthenticated == true && int.TryParse
                (User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId))
            {
                gameDto.UserId = userId;
                gameDto.UserName = User.Identity.Name;
            }

            gameDto.IsGuest = !gameDto.UserId.HasValue;
            
            await _gameService.CreateGameAsync(gameDto);

            return Ok(new
            {
                Message = "Game data received successfully.",
                Data = gameDto
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
