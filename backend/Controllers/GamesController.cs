using Backend.Dto;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
    }
}
