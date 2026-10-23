using Backend.Dto;
using Backend.Exceptions;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Backend.Services.IServices;

namespace Backend.Services
{
	public class CityService : ICityService
	{
		private readonly ICityRepository _cityRepository;
		private readonly IBlobStorageService _blobStorage;
		private readonly ILogger<CityService> _logger;

		public CityService(ICityRepository cityRepository, IBlobStorageService blobStorage, ILogger<CityService> logger)
		{
			_cityRepository = cityRepository;
			_blobStorage = blobStorage;
			_logger = logger;
		}

		public async Task<CityDto> CreateCityAsync(CityCreateDto cityDto)
		{
			var cityExists = await _cityRepository.GetCityByNameAsync(cityDto.Name);

			if (cityExists)
			{
				throw new ConflictException("City with the same name already exists");
			}

			var pictureUrl = await _blobStorage.UploadFileAsync(cityDto.CityPicture);

			var city = new City
			{
				Name = cityDto.Name,
				CityPicture = pictureUrl
			};

			try
			{
				await _cityRepository.CreateCityAsync(city);
				var result = await _cityRepository.SaveChangesAsync();

				if (!result)
				{
					throw new InvalidOperationException("Failed to add city");
				}

			}
			catch
			{
				try
				{
					await _blobStorage.DeleteBlobAsync(pictureUrl);
				}
				catch (Exception ex)
				{

					_logger.LogError(ex, "Failed to delete uploaded picture from blob storage after city creation failed");
				}
				throw;
			}
			return MapToCityDto(city);
		}

		public async Task<List<int>> GetActiveCityIdsAsync()
		{
			return await _cityRepository.GetActiveCityIdsAsync();
		}
		public async Task<IEnumerable<CityDto>> GetActiveCitiesAsync()
		{
			var cities = await _cityRepository.GetActiveCitiesAsync();

			return cities.Select(MapToCityDto);
		}

		public async Task<bool> DeleteCityAsync(int cityId)
		{
			var city = await _cityRepository.GetCityByIdAsync(cityId);

			if (city == null)
			{
				throw new NotFoundException("City not found");
			}

			var pictureUrl = city.CityPicture;
			_cityRepository.DeleteCity(city);
			var result = await _cityRepository.SaveChangesAsync();

			if (!result)
			{
				throw new InvalidOperationException("Failed to delete city");
			}

			try
			{
				await _blobStorage.DeleteBlobAsync(pictureUrl);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to delete picture from blob storage for city with ID {CityId}", cityId);
			}

			return result;
		}

		public async Task ArchiveCityAsync(int cityId)
		{
			var city = await _cityRepository.GetCityByIdAsync(cityId) ??
				throw new NotFoundException("City not found");

			if (city.IsArchived)
			{
				return;
			}

			city.IsArchived = true;

			var saved = await _cityRepository.SaveChangesAsync();

			if (!saved)
			{
				throw new InvalidOperationException("Failed to archive city");
			}
		}

		public async Task RestoreCityAsync(int cityId)
		{
			var city = await _cityRepository.GetCityByIdAsync(cityId) ??
				throw new NotFoundException("City not found");

			if (!city.IsArchived)
			{
				return;
			}

			city.IsArchived = false;

			var saved = await _cityRepository.SaveChangesAsync();

			if (!saved)
			{
				throw new InvalidOperationException("Failed to restore city");
			}
		}

		public async Task<IEnumerable<CityDto>> GetAllCitiesAsync()
		{
			var cities = await _cityRepository.GetAllCitiesAsync();
			return cities.Select(MapToCityDto);
		}

		public async Task<CityDto> GetCityByIdAsync(int cityId)
		{
			var city = await _cityRepository.GetCityByIdAsync(cityId);

			if (city == null)
			{
				throw new NotFoundException("City not found");
			}

			return MapToCityDto(city);
		}

		public async Task<CityDto> UpdateCityAsync(int cityId, CityUpdateDto cityDto)
		{
			var city = await _cityRepository.GetCityByIdAsync(cityId);

			if (city == null)
			{
				throw new NotFoundException("City not found");
			}

			var trimmedCityName = cityDto.Name.Trim();

			if (city.Name != trimmedCityName)
			{
				var cityExists = await _cityRepository.GetCityByNameAsync(trimmedCityName);

				if (cityExists)
				{
					throw new ConflictException("City already exist in the system");
				}
			}

			if (city.Name == trimmedCityName && cityDto.CityPicture == null)
			{
				return MapToCityDto(city);
			}

			city.Name = trimmedCityName;
			var oldPictureUrl = city.CityPicture;

			string? newPicture = null;

			if (cityDto.CityPicture != null)
			{
				newPicture = await _blobStorage.UploadFileAsync(cityDto.CityPicture);
				city.CityPicture = newPicture;
			}

			try
			{
				var result = await _cityRepository.SaveChangesAsync();

				if (!result)
				{
					throw new InvalidOperationException("Failed to update city");
				}
			}
			catch
			{
				try
				{
					if (newPicture != null)
					{
						await _blobStorage.DeleteBlobAsync(newPicture);

					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Failed to delete newly uploaded picture from blob storage after city update failed {CityId}", cityId);

				}
				throw;
			}

			try
			{
				if (newPicture != null && oldPictureUrl != null)
				{
					await _blobStorage.DeleteBlobAsync(oldPictureUrl);
				}
			}
			catch (Exception ex)
			{

				_logger.LogError(ex, "Failed to delete old picture from blob storage for city with ID {CityId}", cityId);
			}

			return MapToCityDto(city);
		}

		public async Task<int> GetCityCountAsync()
		{
			return (await _cityRepository.GetAllCitiesAsync()).Count();
		}

		public async Task UpdateCityQuestionsAsync(int cityId, CityQuestionsUpdateDto updateDto)
		{
    		var city = await _cityRepository.GetCityWithQuestionsAsync(cityId) ??
        		throw new NotFoundException("City not found");

    			ValidateCityQuestions(city, updateDto);

    			ApplyQuestionUpdates(city, updateDto);

    			await _cityRepository.SaveChangesAsync();
		}

		private static void ApplyQuestionUpdates(City city,	CityQuestionsUpdateDto updateDto)
		{
			foreach (var updatedQuestion in updateDto.Questions)
			{
				var question = city.Questions.Single(question => question.QuestionId == updatedQuestion.QuestionId);

				question.QuestionText = updatedQuestion.QuestionText.Trim();

				foreach (var updatedOption in updatedQuestion.Options)
				{
					var option = question.Options.Single(
						option => option.OptionId == updatedOption.OptionId);

					option.OptionText = updatedOption.OptionText.Trim();
					option.IsCorrect = updatedOption.IsCorrect;
				}
			}
		}

		private static void ValidateCityQuestions(City city, CityQuestionsUpdateDto updateDto)
		{
			if (updateDto.Questions == null)
			{
				throw new AppValidationException("Questions are required");
			}

			if (updateDto.Questions.Any(question => question is null))
			{
				throw new AppValidationException("Questions cannot be null");
			}

			var existingIds = city.Questions
				.Select(question => question.QuestionId)
				.ToHashSet();

			var updatedIds = updateDto.Questions
				.Select(question => question.QuestionId)
				.ToList();

			if (updatedIds.Count != existingIds.Count || !existingIds.SetEquals(updatedIds))
			{
				throw new AppValidationException("Include every existing question exactly once. " + "Adding or removing questions is not allowed.");
			}

			foreach (var updatedQuestion in updateDto.Questions)
			{
				if (string.IsNullOrWhiteSpace(updatedQuestion.QuestionText))
				{
					throw new AppValidationException("Question text cannot be empty");
				}

				var existingQuestion = city.Questions.Single(question => question.QuestionId == updatedQuestion.QuestionId);

				ValidateQuestionOptions(existingQuestion, updatedQuestion);
			}

		}

		private static void ValidateQuestionOptions(Question existingQuestion, QuestionUpdateDto updatedQuestion)
		{
			if (updatedQuestion.Options == null)
			{
				throw new AppValidationException("Options cannot be null");
			}

			if (updatedQuestion.Options.Any(option => option is null))
			{
				throw new AppValidationException("Options cannot contain null entries.");
			}

			var existingIds = existingQuestion.Options
				.Select(option => option.OptionId)
				.ToHashSet();

			var updatedIds = updatedQuestion.Options
				.Select(option => option.OptionId)
				.ToList();

			if (updatedIds.Count != existingIds.Count || !existingIds.SetEquals(updatedIds))
			{
				throw new AppValidationException("Include every existing option exactly once. " + "Adding or removing options is not allowed.");
			}

			if (updatedQuestion.Options.Any(option => string.IsNullOrWhiteSpace(option.OptionText)))
			{
				throw new AppValidationException("Option text cannot be empty");
			}

			if (updatedQuestion.Options.Count(option => option.IsCorrect) != 1)
			{
				throw new AppValidationException("Each question must have exactly one correct option.");
			}
		}

		public async Task<CityQuestionsUpdateDto> GetCityQuestionsForEditAsync(int cityId)
		{
			var city = await _cityRepository.GetCityWithQuestionsAsync(cityId) ??
				throw new NotFoundException("City not found");

			return new CityQuestionsUpdateDto
			{
				Questions = city.Questions
					.OrderBy(question => question.QuestionId)
					.Select(question => new QuestionUpdateDto
					{
						QuestionId = question.QuestionId,
						QuestionText = question.QuestionText,
						Options = question.Options
							.OrderBy(option => option.OptionId)
							.Select(option => new OptionUpdateDto
							{
								OptionId = option.OptionId,
								OptionText = option.OptionText,
								IsCorrect = option.IsCorrect
							})
							.ToList()
					})
					.ToList()
			};
		}

		private static CityDto MapToCityDto(City city)
		{
			return new CityDto
			{
				CityId = city.CityId,
				Name = city.Name,
				CityPicture = city.CityPicture
			};
		}
	}
}
