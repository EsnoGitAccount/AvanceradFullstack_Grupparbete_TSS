using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetActiveCities()
        {
            var cities = await _cityService.GetActiveCitiesAsync();

            return Ok(cities);
        }

        // Admin only endpoints 
        [HttpPost("{cityId:int}/archive")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveCity(int cityId)
        {
            await _cityService.ArchiveCityAsync(cityId);

            return NoContent();
        }

        [HttpPost("{cityId:int}/restore")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreCity(int cityId)
        {
            await _cityService.RestoreCityAsync(cityId);

            return NoContent();
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();

            return Ok(cities);
        }
    }
}
