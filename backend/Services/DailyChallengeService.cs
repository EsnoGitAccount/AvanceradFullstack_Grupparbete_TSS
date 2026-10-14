using Backend.Dto;
using Backend.Repositories.IRepositories;
using Backend.Services.IServices;

namespace Backend.Services
{
    public class DailyChallengeService : IDailyChallengeService
    {
        private readonly IDailyChallengeRepository _dailyChallengeRepository;
        private readonly ICityService _cityService;

        public DailyChallengeService(IDailyChallengeRepository dailyChallengeRepository, ICityService cityService)
        {
            _dailyChallengeRepository = dailyChallengeRepository;
            _cityService = cityService;
        }
        public async Task<DailyChallangeDto> GetChallengeForDateAsync(DateOnly date)
        {
            var challenge = await _dailyChallengeRepository.GetChallengeForDate(date);

            if (challenge != null)
            {
                return new DailyChallangeDto
                {
                    CityDetails = new CityDetailsDto
                    {
                        CityName = challenge.City.Name,
                        Clues = challenge.City.Clues.Select(c => new ClueDto
                        {
                            ClueText = c.ClueText
                        }).ToList(),
                        Questions = challenge.City.Questions.Select(q => new QuestionDto
                        {
                            QuestionText = q.QuestionText
                        }).ToList()
                    },
                    ChallangeDate = challenge.ChallangeDate
                };
            }
            else
            {
                var lastChallenge = await _dailyChallengeRepository.GetLastChallenge();

                var amountCities = await _cityService.GetCityCountAsync();
                var newChallenge = await _dailyChallengeRepository.CreateDailyChallenge(date, 1); // Replace 1 with the actual city ID

                throw new NotImplementedException();
            }
        }
    }
}
