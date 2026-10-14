using Backend.Repositories.IRepositories;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyChallengeController : ControllerBase
    {
        private readonly IDailyChallengeService _dailyChallengeService;
        public DailyChallengeController(IDailyChallengeService dailyChallengeService)
        {
            _dailyChallengeService = dailyChallengeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDailyCity()
        {
            var dailyCity = await _dailyChallengeService.GetChallengeForDateAsync(DateOnly.FromDateTime(DateTime.Today));
            return Ok(dailyCity);
        }
    }
}
