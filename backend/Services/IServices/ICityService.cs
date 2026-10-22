using Backend.Dto;


namespace Backend.Services.IServices
{
	public interface ICityService
	{
		Task<IEnumerable<CityDto>> GetAllCitiesAsync();
		Task<List<int>> GetActiveCityIdsAsync();
        Task<IEnumerable<CityDto>> GetActiveCitiesAsync();
        Task<CityDto> GetCityByIdAsync(int cityId);
		Task<CityDto> CreateCityAsync(CityCreateDto cityDto);
		Task<bool> DeleteCityAsync(int cityId);
		Task ArchiveCityAsync(int cityId);
        Task RestoreCityAsync(int cityId);
        Task<CityDto> UpdateCityAsync(int cityId, CityUpdateDto cityDto);
		Task<int> GetCityCountAsync();
		//Task<int> GetRandomCityIdAsync(int? excludeCityId);
    }
}
