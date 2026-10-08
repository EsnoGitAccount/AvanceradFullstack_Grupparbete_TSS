using Backend.Data;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class CityRepository : ICityReposistory
    {
        private readonly WhereAreWeDbContext _context;

        public CityRepository(WhereAreWeDbContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllCitiesAsync()
        {
            return await _context.Cities
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
