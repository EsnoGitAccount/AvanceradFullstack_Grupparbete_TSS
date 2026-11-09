using Microsoft.AspNetCore.DataProtection;
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
        private readonly Mock<IGameRepository> _mockGameRepo;
        private readonly Mock<IDailyChallengeRepository> _dailyChallengeMockRepo;
        private readonly Mock<IUserRepository> _userMockRepo;
        public GameServiceTests()
        {
            _mockGameRepo = new Mock<IGameRepository>();
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

            _mockGameRepo.Setup(r => r.CreateGameAsync(It.IsAny<Game>())).ReturnsAsync((Game game) =>
            {
                game.GameId = 1;
                return game;
            });

            _mockGameRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(true);

            var service = new GameService(_mockGameRepo.Object, _dailyChallengeMockRepo.Object, _userMockRepo.Object, new EphemeralDataProtectionProvider());

            // Act
            var gameId = await service.CreateGameAsync(gameDto);

            // Assert - verify mapping and that repo was called once
            _mockGameRepo.Verify(r => r.CreateGameAsync(It.Is<Game>(g =>
                g.UserName == gameDto.UserName &&
                g.UserId == gameDto.UserId &&
                g.TotalScore == (int)gameDto.FinalScore &&
                g.CompletedAt == gameDto.CompletedAt &&
                g.DailyChallangeId == todaysChallenge.DailyChallangeId
            )), Times.Once);
        }

        // @Esbjörn Please add tests for getting and setting streaks here using interrupted streaks/gaps and existing streaks
        [Theory]
        [InlineData(true, 6)]
        [InlineData(false, 1)]
        public async Task SetStreakForUserAsync_IfUserPlayedYesterday_AddOneToCurrentStreakAndReturnIt(bool userPlayedYesterday, int expectedStreak)
        {
            // Assign
            var todaysDate = DateOnly.FromDateTime(DateTime.Today);

            // Create user and game data
            var testUser = new User
            {
                Id = 1,
                UserName = "Test",
                CurrentStreak = 5
            };

            var testGameDto = new GameDto
            {
                UserName = testUser.UserName,
                UserId = testUser.Id,
                IsGuest = false,
                FinalScore = 26,
                CompletedAt = todaysDate
            };

            var testGame = new Game
            {
                GameId = 11,
                UserName = testUser.UserName,
                UserId = testUser.Id,
                CompletedAt = todaysDate,
                DailyChallangeId = 1,
                TotalScore = 26
            };


            var testDailyChallenge = new DailyChallange
            {
                DailyChallangeId = 1,
                CityId = 10,
                City = new City
                {
                    CityId = 10,
                    IsArchived = false
                },
                ChallangeDate = todaysDate
            };

            // Configure mocks
            _mockGameRepo.Setup(repo => repo.GetUserPlayedYesterdayAsync(testUser.Id)).ReturnsAsync(userPlayedYesterday);
            _mockGameRepo.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);
            _userMockRepo.Setup(repo => repo.GetUserByIdAsync(testUser.Id)).ReturnsAsync(testUser);
            _mockGameRepo
                .Setup(repo => repo.CreateGameAsync(It.Is<Game>(game =>
                    game.UserName == testUser.UserName &&
                    game.UserId == testUser.Id &&
                    game.CompletedAt == todaysDate &&
                    game.DailyChallangeId == testDailyChallenge.DailyChallangeId &&
                    game.TotalScore == 26)))
                .ReturnsAsync(testGame);

            _userMockRepo.Setup(repo => repo.UpdateUserStreakAsync(testUser, 5)).ReturnsAsync(true);

            _dailyChallengeMockRepo.Setup(repo => repo.GetChallengeForDate(todaysDate)).ReturnsAsync(testDailyChallenge);

            // Create Service
            var service = new GameService(_mockGameRepo.Object, _dailyChallengeMockRepo.Object, _userMockRepo.Object, new EphemeralDataProtectionProvider());

            // Act
            await service.CreateGameAsync(testGameDto);


            // Assert
            _userMockRepo.Verify(
                    repo => repo.UpdateUserStreakAsync(
                        testUser,
                        expectedStreak
                    ),
                    Times.Once
                );
        }
    }
}
