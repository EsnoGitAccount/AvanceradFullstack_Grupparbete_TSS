using Backend.Dto;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;

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
            await _gameService.CreateGameAsync(gameDto);

            return Ok(new
            {
                Message = "Game data received successfully.",
                Data = gameDto
            });

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
