using Backend.Dto;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Backend.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Tests.Services
{
    public class GameServiceTests
    {
        private readonly Mock<IGameRepository> _mockRepo;
        private readonly Mock<IDailyChallengeRepository> _dailyChallengeMockRepo;
        private readonly Mock<IUserRepository> _userMockRepo;

        public GameServiceTests()
        {
            _mockRepo = new Mock<IGameRepository>();
            _dailyChallengeMockRepo = new Mock<IDailyChallengeRepository>();
            _userMockRepo = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task CreateGameAsync_CallsRepositoryWithMappedGame_WhenRepositoryReturnsTrue()
        {
            // Arrange
            var gameDto = new GameDto
            {
                UserName = "player1",
                UserId = 42,
                FinalScore = 99.5m,
                CompletedAt = DateOnly.FromDateTime(new DateTime(2026, 10, 01))
            };
            var todaysChallenge = new DailyChallange
            {
                DailyChallangeId = 1,
                City = new City { CityId = 1, Name = "TestCity", IsArchived = false }
            };

            _dailyChallengeMockRepo.Setup(r => r.GetChallengeForDate(It.IsAny<DateOnly>()))
                .ReturnsAsync(todaysChallenge);

            _userMockRepo.Setup(r => r.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(new User { UserName = "player1" });

            _mockRepo.Setup(r => r.CreateGameAsync(It.IsAny<Game>())).ReturnsAsync(1);

            var service = new GameService(_mockRepo.Object, _dailyChallengeMockRepo.Object, _userMockRepo.Object);

            // Act
            var gameId = await service.CreateGameAsync(gameDto);

            // Assert - verify mapping and that repo was called once
            _mockRepo.Verify(r => r.CreateGameAsync(It.Is<Game>(g =>
                g.UserName == gameDto.UserName &&
                g.UserId == gameDto.UserId &&
                g.TotalScore == (int)gameDto.FinalScore &&
                g.CompletedAt == gameDto.CompletedAt &&
                g.DailyChallangeId == todaysChallenge.DailyChallangeId
            )), Times.Once);
        }
    }
}
