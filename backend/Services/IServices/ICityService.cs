using Backend.Model;

namespace Backend.Services.IServices
{
    public interface ICityService
    {
        Task <List<City>>? GetAllCitiesAsync();

        Task<int> GetCityCountAsync();
    }
}
