using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Backend.Services.IServices;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly WhereAreWeDbContext _context;
        private readonly ICityService _cityService;

        public CitiesController(WhereAreWeDbContext context, ICityService cityService)
        {
            _context = context;
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = _cityService.GetAllCitiesAsync();

            return Ok(cities);
        }
    }
}
