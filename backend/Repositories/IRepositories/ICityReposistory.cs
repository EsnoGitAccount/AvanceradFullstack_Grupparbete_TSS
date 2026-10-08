using Backend.Model;

namespace Backend.Repositories.IRepositories
{
    public interface ICityReposistory
    {
        Task<List<City>> GetAllCitiesAsync();
    }
}
