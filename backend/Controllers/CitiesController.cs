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
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();

            return Ok(cities);
        }
    }
}
