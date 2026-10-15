using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Backend.Repositories.IRepositories;
using Backend.Model;
using Backend.Services;
using Backend.Services.IServices;
using Microsoft.Extensions.Logging;

namespace Backend.Tests.Services
{
	public class CityServiceTests
	{
		[Fact]
		public async Task GivenGetAllCities_ReturnsListOfCities()
		{
			// Arrange
			var mockRepo = new Mock<ICityRepository>();
			var mockBlobStorage = new Mock<IBlobStorageService>();
			var mockLogger = new Mock<ILogger<CityService>>();

			var expectedCities = new List<City>
			{
				new City { CityId = 1, Name = "City1", CityPicture = "blob1" },
				new City { CityId = 2, Name = "City2", CityPicture = "blob2" }
			};

			mockRepo.Setup(repo => repo.GetAllCitiesAsync()).ReturnsAsync(expectedCities);

			var cityService = new CityService(mockRepo.Object, mockBlobStorage.Object, mockLogger.Object);

			// Act
			var result = await cityService.GetAllCitiesAsync();
			var resultList = result.ToList();
			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedCities.Count, resultList.Count);
			Assert.Equal(expectedCities[0].CityId, resultList[0].CityId);
			Assert.Equal(expectedCities[0].Name, resultList[0].Name);
			mockRepo.Verify(repo => repo.GetAllCitiesAsync(), Times.Once);
		}
	}	
}
