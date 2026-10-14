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

		public async Task<CityDto> AddAsync(CityCreateDto cityDto)
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
				await _cityRepository.AddAsync(city);
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

		public async Task<bool> DeleteAsync(int cityId)
		{
			var city = await _cityRepository.GetCityByIdAsync(cityId);

			if (city == null)
			{
				throw new NotFoundException("City not found");
			}

			var pictureUrl = city.CityPicture;
			_cityRepository.Delete(city);
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

		public async Task<CityDto> UpdateAsync(int cityId, CityUpdateDto cityDto)
		{
			var city = await _cityRepository.GetCityByIdAsync(cityId);

			if (city == null)
			{
				throw new NotFoundException("City not found");
			}

			if (city.Name != cityDto.Name)
			{
				var cityExists = await _cityRepository.GetCityByNameAsync(cityDto.Name);

				if (cityExists)
				{
					throw new ConflictException("City already exist in the system");
				}
			}

			if (city.Name == cityDto.Name && cityDto.CityPicture == null)
			{
				return MapToCityDto(city);
			}

			city.Name = cityDto.Name;
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
