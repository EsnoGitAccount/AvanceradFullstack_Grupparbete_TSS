using System.Collections.Generic;
using Backend.Services;
using Xunit;

namespace Backend.Tests.Services
{
    public class ClityRandomizerTests
    {
        [Fact]
        public void SelectNextCityId_ReturnsCityId_WhenRecentlyCityIsExcluded()
        {
            // Arrange
            var randomizer = new CityRandomizer();
            var recentCityIds = new List<int> { 1 };
            int totalCities = 2;

            // Act
            var result = randomizer.SelectNextCityId(recentCityIds, totalCities);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result);
        }

        [Fact]
        public void SelectNextCityId_ReturnsNull_WhenTotalCitiesIsZero()
        {
            // Arrange
            var randomizer = new CityRandomizer();
            var recentCityIds = new List<int>();
            int totalCities = 0;

            // Act
            var result = randomizer.SelectNextCityId(recentCityIds, totalCities);

            // Assert
            Assert.Null(result);
        }
    }
}
