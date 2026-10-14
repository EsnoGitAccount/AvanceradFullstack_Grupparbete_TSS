using Backend.Dto;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Backend.Services.IServices;

namespace Backend.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IDailyChallengeRepository _dailyChallengeRepository;

        public GameService(IGameRepository gameRepository, IDailyChallengeRepository dailyChallengeRepository)
        {
            _gameRepository = gameRepository;
            _dailyChallengeRepository = dailyChallengeRepository;
        }
        public async Task CreateGameAsync(GameDto gameDto)
        {
            var todaysChallenge = await _dailyChallengeRepository.GetChallengeForDate(DateOnly.FromDateTime(DateTime.UtcNow));

            var game = new Game
            {
                UserName = gameDto.UserName ?? null,
                UserId = gameDto.UserId ?? null,
                TotalScore = (int)gameDto.FinalScore,
                CompletedAt = gameDto.CompletedAt == default(DateOnly) ? DateOnly.FromDateTime(DateTime.UtcNow) : gameDto.CompletedAt,
                DailyChallangeId = todaysChallenge.DailyChallangeId // This should be bouncing on cache in the future!
            };

            var result = await _gameRepository.CreateGameAsync(game);

            if (result != true)
            {
                throw new InvalidOperationException("Failed to create game.");
            }
            else
            {
                return;
            }
        }
    }
}
