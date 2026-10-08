using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Backend.Repositories.IRepositories;
using Backend.Model;
using Backend.Services;

namespace Backend.Tests.Services
{
    public class CitiyServiceTests
    {
        [Fact]
        public async Task GivenGetAllCities_ReturnsListOfCities()
        {
            // Arrange
            var mockRepo = new Mock<ICityReposistory>();
            var expectedCities = new List<City>
            {
                new City { CityId = 1, Name = "City1" },
                new City { CityId = 2, Name = "City2" }
            };

            mockRepo.Setup(repo => repo.GetAllCitiesAsync()).ReturnsAsync(expectedCities);

            var cityService = new CityService(mockRepo.Object);

            // Act
            var result = await cityService.GetAllCitiesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCities.Count, result.Count);
            Assert.Equal(expectedCities[0].CityId, result[0].CityId);
            Assert.Equal(expectedCities[0].Name, result[0].Name);
            mockRepo.Verify(repo => repo.GetAllCitiesAsync(), Times.Once);
        }
    }
}
