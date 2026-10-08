using Backend.Model;
using Backend.Repositories.IRepositories;
using Backend.Services.IServices;

namespace Backend.Services
{
    public class CityService :ICityService
    {
        private readonly ICityReposistory _cityRepository;

        public CityService(ICityReposistory cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<City>> GetAllCitiesAsync()
        {
            return await _cityRepository.GetAllCitiesAsync();
        }
    }
}
