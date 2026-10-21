using System.Collections.Generic;
using Backend.Services;
using Xunit;

namespace Backend.Tests.Services
{
    public class ClityRandomizerTests
    {
        // OLD TEST
        // [Fact]
        // public void SelectNextCityId_ReturnsCityId_WhenRecentlyCityIsExcluded()
        // {
        // // Arrange
        // var randomizer = new CityRandomizer();
        // var recentCityIds = new List<int> { 1 };
        // int totalCities = 2;
        // 
        // // Act
        // var result = randomizer.SelectNextCityId(recentCityIds, totalCities);
        // 
        // // Assert
        // Assert.NotNull(result);
        // Assert.Equal(2, result);
        // }
        // 
        // [Fact]
        // public void SelectNextCityId_ReturnsNull_WhenTotalCitiesIsZero()
        // {
        // // Arrange
        // var randomizer = new CityRandomizer();
        // var recentCityIds = new List<int>();
        // int totalCities = 0;
        // 
        // // Act
        // var result = randomizer.SelectNextCityId(recentCityIds, totalCities);
        // 
        // // Assert
        // Assert.Null(result);
        // }
        private readonly CityRandomizer _cityRandomizer;
        private readonly List<int> _recentCityIds;
        private readonly List<int> _eligibleCityIds;

        public ClityRandomizerTests()
        {
            _cityRandomizer = new CityRandomizer();
            _recentCityIds = new List<int>();
            _eligibleCityIds = new List<int>();
        }

        [Fact]
        public void SelectNextCityId_ReturnsCityId_WhenRecentCityIsExcludedAndIdsHaveGaps()
        {
            // Arrange

            _recentCityIds.Add(1);
            _eligibleCityIds.AddRange(new List<int> { 1, 4 });

            // Act
            var result = _cityRandomizer.SelectNextCityId(_recentCityIds, _eligibleCityIds);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result);
        }

        [Fact]
        public void SelectNextCityId_ReturnsNull_WhenNoEligibleCities()
        {
            // Act
            var result = _cityRandomizer.SelectNextCityId(_recentCityIds, _eligibleCityIds);

            // Assert
            Assert.Null(result);
        }
    }
}

