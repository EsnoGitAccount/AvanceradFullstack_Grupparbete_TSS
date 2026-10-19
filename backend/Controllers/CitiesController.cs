using Microsoft.AspNetCore.Mvc;
using Backend.Services.IServices;
using Backend.Dto;
using Microsoft.AspNetCore.Authorization;

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

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> CreateCity([FromForm] CityCreateDto cityDto)
		{
			var createdCity = await _cityService.CreateCityAsync(cityDto);

			return Ok(createdCity);

		}

		[HttpPut("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> UpdateCity(int id, [FromForm] CityUpdateDto cityDto)
		{
			var updatedCity = await _cityService.UpdateCityAsync(id, cityDto);

			return Ok(updatedCity);
		}

		//[HttpDelete("{id}")]
		//[Authorize(Roles = "Admin")]
		//public async Task<IActionResult> DeleteCity(int id)
		//{
		//	await _cityService.DeleteCityAsync(id);

		//	return NoContent();
		//}

	}
}
