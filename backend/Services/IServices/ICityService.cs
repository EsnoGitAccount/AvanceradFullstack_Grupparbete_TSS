using Backend.Dto;


namespace Backend.Services.IServices
{
	public interface ICityService
	{
		Task<IEnumerable<CityDto>> GetAllCitiesAsync();
		Task<CityDto> GetCityByIdAsync(int cityId);
		Task<CityDto> AddAsync(CityCreateDto cityDto);
		Task<bool> DeleteAsync(int cityId);
		Task<CityDto> UpdateAsync(int cityId, CityUpdateDto cityDto);

	}
}
