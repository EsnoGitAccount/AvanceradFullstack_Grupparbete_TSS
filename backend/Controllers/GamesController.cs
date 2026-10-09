using Backend.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostGame([FromBody] GameDto gameDto)
        {
            // Here you would typically save the game data to a database or perform other processing.
            // For this example, we'll just return the received data as a confirmation.
            return Ok(new
            {
                Message = "Game data received successfully.",
                Data = gameDto
            });
        }
    }
}
