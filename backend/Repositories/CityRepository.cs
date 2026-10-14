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

		public async Task AddAsync(City city)
		{
			await _context.Cities.AddAsync(city);
		}

		public void Delete(City city)
		{
			_context.Cities.Remove(city);
		}

		public async Task<IEnumerable<City>> GetAllCitiesAsync()
		{
			return await _context.Cities
				.AsNoTracking()
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

		public async Task<bool> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}

	}
}
