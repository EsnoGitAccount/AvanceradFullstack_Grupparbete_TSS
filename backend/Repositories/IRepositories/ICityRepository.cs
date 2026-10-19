using Backend.Model;

namespace Backend.Repositories.IRepositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City?> GetCityByIdAsync(int cityId);
        Task<bool> GetCityByNameAsync(string cityName);
        Task CreateCityAsync(City city);
        void DeleteCity(City city);
        Task<bool> SaveChangesAsync();
    }
}
