using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Backend.Services.IServices;
using Backend.Dto;

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

		[HttpPost]
		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateCity([FromForm] CityCreateDto cityDto)
		{
			var createdCity = await _cityService.CreateCityAsync(cityDto);

			return Ok(createdCity);

		}

		[HttpPut("{id}")]
		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateCity(int id, [FromForm] CityUpdateDto cityDto)
		{
			var updatedCity = await _cityService.UpdateCityAsync(id, cityDto);

			return Ok(updatedCity);
		}

		[HttpPut("{cityId:int}/questions")]
		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateCityQuestions(int cityId, [FromBody] CityQuestionsUpdateDto updateDto)
		{
			await _cityService.UpdateCityQuestionsAsync(cityId, updateDto);

			return Ok();
		}
		
		[HttpGet("{cityId:int}/questions")]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<CityQuestionsUpdateDto>> GetCityQuestionsForEdit(int cityId)
		{
			var questions = await _cityService
				.GetCityQuestionsForEditAsync(cityId);

			return Ok(questions);
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
