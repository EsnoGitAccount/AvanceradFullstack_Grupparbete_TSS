using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly WhereAreWeDbContext _context;

        public CitiesController(WhereAreWeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _context.Cities
                .AsNoTracking()
                .ToListAsync();

            return Ok(cities);
        }
    }
}
