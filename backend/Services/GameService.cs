using Backend.Dto;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Backend.Services.IServices;

namespace Backend.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task CreateGameAsync(GameDto gameDto)
        {
            var game = new Game
            {
                UserName = gameDto.UserName ?? null,
                UserId = gameDto.UserId ?? null,
                TotalScore = (int)gameDto.FinalScore,
                CompletedAt = gameDto.CompletedAt == default(DateOnly) ? DateOnly.FromDateTime(DateTime.UtcNow) : gameDto.CompletedAt,
                DailyChallangeId = 1 // Assuming a default value for DailyChallangeId for testing
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
