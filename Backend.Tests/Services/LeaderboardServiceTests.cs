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
    public class LeaderboardServiceTests
    {
        [Fact]
        public async Task GetAsync_WhenCalled_ReturnsLeaderboardDto()
        {
            // Arrange

            int userId = 1;
            int gameId = 1;

            var mockUserRepo = new Mock<IUserRepository>();
            mockUserRepo.Setup(repo => repo.GetUserByIdAsync(userId))
                .ReturnsAsync(new User { Id = userId});

            var mockGameRepo = new Mock<IGameRepository>();
            mockGameRepo.Setup(repo => repo.GetAllGamesAsync()).
                ReturnsAsync(new List<Game> {
                    new Game { GameId = 1 }, 
                    new Game { GameId = 2 },
                    new Game { GameId = 3 }
                });

            LeaderboardService mockLeaderBoardService = new LeaderboardService(mockGameRepo.Object, mockUserRepo.Object);

            // Act
            var result = await mockLeaderBoardService.GetAsync(userId, gameId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<LeaderboardDto>(result);
        }
    }
}
