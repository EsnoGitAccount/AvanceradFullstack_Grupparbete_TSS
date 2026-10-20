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
using Backend.Dto;
using Microsoft.AspNetCore.Http;

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


		[Fact]
		public async Task GivenCreateCity_WhenCityDoesNotExist_CreatesCity()
		{
			// Arrange
			var mockRepo = new Mock<ICityRepository>();
			var mockBlobStorage = new Mock<IBlobStorageService>();
			var mockLogger = new Mock<ILogger<CityService>>();
			var content = Encoding.UTF8.GetBytes("test image");
			var stream = new MemoryStream(content);

			var file = new FormFile(
				stream,
				0,
				stream.Length,
				"file",
				"test.jpg"
			);
			// Set the headers and content type for the FormFile
			file.Headers = new HeaderDictionary();
			file.ContentType = "image/jpeg";


			var cityDto = new CityCreateDto
			{
				Name = "NewCity",
				CityPicture = file
			};

			mockRepo.Setup(repo=>repo.GetCityByNameAsync(cityDto.Name)).ReturnsAsync(false);
			mockBlobStorage.Setup(blob => blob.UploadFileAsync(It.IsAny<IFormFile>())).ReturnsAsync("blobName");
			mockRepo.Setup(repo => repo.CreateCityAsync(It.IsAny<City>())).Returns(Task.CompletedTask);
			mockRepo.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

			var cityService = new CityService(mockRepo.Object, mockBlobStorage.Object, mockLogger.Object);

			// Act
			var result = await cityService.CreateCityAsync(cityDto);
		
			// Assert
			Assert.NotNull(result);
			Assert.Equal(cityDto.Name, result.Name);
			Assert.Equal("blobName", result.CityPicture);
			mockRepo.Verify(repo => repo.GetCityByNameAsync(cityDto.Name), Times.Once);
			mockRepo.Verify(repo => repo.CreateCityAsync(It.IsAny<City>()), Times.Once);
		}

		[Fact]
		public async Task GivenGetCityById_WhenCityExists_ReturnsCity()
		{
			// Arrange
			var mockRepo = new Mock<ICityRepository>();
			var mockBlobStorage = new Mock<IBlobStorageService>();
			var mockLogger = new Mock<ILogger<CityService>>();

			var cityId = 1;
			var expectedCity = new City { CityId = cityId, Name = "City1", CityPicture = "blob1" };

			mockRepo.Setup(repo => repo.GetCityByIdAsync(cityId)).ReturnsAsync(expectedCity);
			var cityService = new CityService(mockRepo.Object, mockBlobStorage.Object, mockLogger.Object);
			// Act
			var result = await cityService.GetCityByIdAsync(cityId);
			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedCity.CityId, result.CityId);
			Assert.Equal(expectedCity.CityPicture, result.CityPicture);
			Assert.Equal(expectedCity.Name, result.Name);
			mockRepo.Verify(repo => repo.GetCityByIdAsync(cityId), Times.Once);
		}

		[Fact]
		public async Task GivenUpdateCity_WhenNameChanges_UpdatesCity()
		{

			// Arrange
			var mockRepo = new Mock<ICityRepository>();
			var mockBlobStorage = new Mock<IBlobStorageService>();
			var mockLogger = new Mock<ILogger<CityService>>();

			var cityId = 1;
			var expectedCity = new City { CityId = cityId, Name = "City1", CityPicture = "blob1" };

			var cityUpdateDto = new CityUpdateDto
			{
				Name = "UpdatedCity",
				CityPicture = null // No picture update
			};

			mockRepo.Setup(repo => repo.GetCityByIdAsync(cityId)).ReturnsAsync(expectedCity);
			mockRepo.Setup(repo=>repo.GetCityByNameAsync(cityUpdateDto.Name)).ReturnsAsync(false);
			mockRepo.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);
			var cityService = new CityService(mockRepo.Object, mockBlobStorage.Object, mockLogger.Object);

			//Act
			var result = await cityService.UpdateCityAsync(cityId, cityUpdateDto);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(cityUpdateDto.Name, result.Name);
			Assert.Equal(expectedCity.CityId, result.CityId);

			Assert.Equal("blob1", result.CityPicture);
			mockRepo.Verify(repo => repo.GetCityByIdAsync(cityId), Times.Once);
			mockRepo.Verify(repo => repo.GetCityByNameAsync(cityUpdateDto.Name), Times.Once);
			mockRepo.Verify(repo => repo.SaveChangesAsync(), Times.Once);
		}
	}	
}
