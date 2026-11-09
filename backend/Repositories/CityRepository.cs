using System.Data;
using Backend.Exceptions;
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

        public async Task<T> WithCityContentTransactionAsync<T>(int cityId, Func<City, Task<T>> action)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                // A retry must reload the city rather than reuse an earlier tracked draft.
                _context.ChangeTracker.Clear();
                await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
                var city = await GetCityWithQuestionsAsync(cityId) ?? throw new NotFoundException("City not found");
                var result = await action(city);
                await transaction.CommitAsync();
                return result;
            });
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
                .Where(city => !city.IsArchived && city.Questions.Count == 2 && city.Clues.Count == 5 &&
                    city.Questions.All(question => question.Options.Count == 4 &&
                        question.Options.Count(option => option.IsCorrect) == 1))
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
                .Include(city => city.Clues)
                .FirstOrDefaultAsync(city => city.CityId == cityId);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
