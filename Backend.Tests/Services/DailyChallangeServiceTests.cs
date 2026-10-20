using Backend.Exceptions;
using Backend.Repositories.IRepositories;
using Backend.Services;
using Backend.Services.IServices;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Tests.Services
{
    public class DailyChallangeServiceTests
    {
        // OLD TEST
        // [Fact]
        // public async Task GetChallengeForDateAsync_ThrowsNotFoundException_WhenNoCitiesFound()
        // {
        // //Arrange
        // var testDate = new DateOnly(2026, 10, 16);
        // 
        // var mockChallengeRepo = new Mock<IDailyChallengeRepository>();
        // var mockCityService = new Mock<ICityService>();
        // 
        // // Mocks
        // mockChallengeRepo.Setup(r => r.GetChallengeForDate(testDate))
        // .ReturnsAsync((Model.DailyChallange?)null);
        // 
        // mockChallengeRepo.Setup(r => r.GetLastChallenge())
        // .ReturnsAsync((Model.DailyChallange?)null);
        // 
        // mockCityService.Setup(s => s.GetCityCountAsync())
        // .ReturnsAsync(0);
        // 
        // var service = new DailyChallengeService(mockChallengeRepo.Object, mockCityService.Object);
        // 
        // // Act & Assert
        // await Assert.ThrowsAsync<NotFoundException>(() => service.GetChallengeForDateAsync(testDate));
        // }

        [Fact]
        public async Task GetChallengeForDateAsync_ThrowsNotFoundException_WhenNoCitiesFound()
        {
            //Arrange
            var testDate = new DateOnly(2026, 10, 16);

            var mockChallengeRepo = new Mock<IDailyChallengeRepository>();
            var mockCityService = new Mock<ICityService>();

            // Mocks
            mockChallengeRepo.Setup(r => r.GetChallengeForDate(testDate))
                .ReturnsAsync((Model.DailyChallange?)null);

            mockChallengeRepo.Setup(r => r.GetLastChallenge())
                .ReturnsAsync((Model.DailyChallange?)null);

            mockCityService.Setup(s => s.GetActiveCityIdsAsync())
                .ReturnsAsync(new List<int>());

            var service = new DailyChallengeService(mockChallengeRepo.Object, mockCityService.Object);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => service.GetChallengeForDateAsync(testDate));

            mockCityService.Verify(s => s.GetActiveCityIdsAsync(), Times.Once);
            mockChallengeRepo.Verify(
                r => r.CreateDailyChallenge(It.IsAny<DateOnly>(), It.IsAny<int>()),
                Times.Never);
        }
    }
}

