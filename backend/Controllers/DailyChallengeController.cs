using Backend.Repositories.IRepositories;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyChallengeController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly IDailyChallengeService _dailyChallengeService;
        public DailyChallengeController(IDailyChallengeService dailyChallengeService, IMemoryCache cache)
        {
            _dailyChallengeService = dailyChallengeService;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> GetDailyCity([FromQuery] DateOnly? date)
        {
            var now = DateTime.UtcNow;
            var challengeDate = date ?? DateOnly.FromDateTime(now);

            var cacheKey = $"DailyChallenge_{challengeDate:yyyy-MM-dd}";

            var dailyCity = await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpiration = new DateTimeOffset(now.Date.AddDays(1));
                return await _dailyChallengeService.GetChallengeForDateAsync(challengeDate);
            });

            return Ok(dailyCity);
        }
    }
}
