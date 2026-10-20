using Backend.Data;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
	public class CityRepository : ICityRepository
	{
		private readonly WhereAreWeDbContext _context;

		public CityRepository(WhereAreWeDbContext context)
		{
			_context = context;
		}

		public async Task CreateCityAsync(City city)
		{
			await _context.Cities.AddAsync(city);
		}

		public void DeleteCity(City city)
		{
			_context.Cities.Remove(city);
		}

		public async Task<IEnumerable<City>> GetAllCitiesAsync()
		{
			return await _context.Cities
				.AsNoTracking()
				.ToListAsync();
		}

        public async Task<List<int>> GetActiveCityIdsAsync()
        {
            return await _context.Cities
                .Where(city => !city.IsArchived)
                .OrderBy(city => city.CityId)
                .Select(city => city.CityId)
                .ToListAsync();
        }
        public async Task<IEnumerable<City>> GetActiveCitiesAsync()
        {
            return await _context.Cities
                .AsNoTracking()
                .Where(city => !city.IsArchived)
                .OrderBy(city => city.CityId)
                .ToListAsync();
        }

        public async Task<City?> GetCityByIdAsync(int cityId)
		{
			return await _context.Cities
				.FirstOrDefaultAsync(c => c.CityId == cityId);
		}

		public async Task<bool> GetCityByNameAsync(string cityName)
		{
			return await _context.Cities
				.FirstOrDefaultAsync(c => c.Name == cityName) != null;
		}

		public async Task<City?> GetCityWithQuestionsAsync(int cityId)
		{
    		return await _context.Cities
        		.Include(city => city.Questions)
            	.ThenInclude(question => question.Options)
        		.FirstOrDefaultAsync(city => city.CityId == cityId);
		}

		
		public async Task<bool> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}

	}
}
