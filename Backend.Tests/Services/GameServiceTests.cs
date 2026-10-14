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
            var todaysChallenge = new DailyChallangeDto
            {
                CityDetails = new CityDetailsDto
                {
                    CityName = "TestCity",
                    Clues = new List<ClueDto>(),
                    Questions = new List<QuestionDto>()
                }
            };

            var mockRepo = new Mock<IGameRepository>();
            var secondMockRepo = new Mock<IDailyChallengeRepository>(); //appease the args

            secondMockRepo.Setup(r => r.GetChallengeForDate(It.IsAny<DateOnly>()))
                .ReturnsAsync(new DailyChallange { DailyChallangeId = 1 });

            mockRepo.Setup(r => r.CreateGameAsync(It.IsAny<Game>())).ReturnsAsync(true);

            var service = new GameService(mockRepo.Object, secondMockRepo.Object);

            // Act
            await service.CreateGameAsync(gameDto);

            // Assert - verify mapping and that repo was called once
            mockRepo.Verify(r => r.CreateGameAsync(It.Is<Game>(g =>
                g.UserName == gameDto.UserName &&
                g.UserId == gameDto.UserId &&
                g.TotalScore == (int)gameDto.FinalScore &&
                g.CompletedAt == gameDto.CompletedAt
            )), Times.Once);
        }
    }
}
