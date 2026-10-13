using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/errortest/[controller]")]
    public class ErrorTestControllers : ControllerBase
    {
        [HttpGet("400")]
        public IActionResult Get400()
        {
            return BadRequest();
        }

        [HttpGet("404")]
        public IActionResult Get404()
        {
            return NotFound();
        }

        [HttpGet("500")]
        public IActionResult Get500()
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
