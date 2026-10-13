using Backend.Dto;
using Backend.Repositories.IRepositories;
using Backend.Services.IServices;

namespace Backend.Services
{
    public class DailyChallengeService : IDailyChallengeService
    {
        private readonly IDailyChallengeRepository _dailyChallengeRepository;

        public DailyChallengeService(IDailyChallengeRepository dailyChallengeRepository)
        {
            _dailyChallengeRepository = dailyChallengeRepository;
        }
        public async Task<DailyChallangeDto> GetChallengeForDateAsync(DateOnly date)
        {
            var challenge = await _dailyChallengeRepository.GetChallengeForDateAsync(date);

            if (challenge != null)
            {
                return new DailyChallangeDto
                {
                    Id = challenge.Id,
                    CityDetails = new CityDetailsDto
                    {
                        Name = challenge.CityDetails.Name,
                        Country = challenge.CityDetails.Country,
                        Population = challenge.CityDetails.Population
                    },
                    ChallangeDate = challenge.ChallangeDate
                };
            }
            else
            {
                throw new Exception($"No challenge found for date {date}");
            }
        }
    }
}
