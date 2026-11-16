using Backend.Model;

namespace Backend.Repositories.IRepositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<List<int>> GetActiveCityIdsAsync();
        Task<IEnumerable<City>> GetActiveCitiesAsync();
        Task<City?> GetCityByIdAsync(int cityId);
        Task<bool> GetCityByNameAsync(string cityName);
        Task CreateCityAsync(City city);
        Task<T> WithCityContentTransactionAsync<T>(int cityId, Func<City, Task<T>> action);
        void DeleteCity(City city);
        Task<bool> SaveChangesAsync();
        Task<City?> GetCityWithQuestionsAsync(int cityId);
    }
}
