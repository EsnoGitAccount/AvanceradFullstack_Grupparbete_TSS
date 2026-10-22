using Backend.Dto;
using Backend.Exceptions;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Backend.Services.IServices;

namespace Backend.Services
{
    public class DailyChallengeService : IDailyChallengeService
    {
        private readonly IDailyChallengeRepository _dailyChallengeRepository;
        private readonly ICityService _cityService;
        private readonly CityRandomizer _cityRandomizer;

        public DailyChallengeService(IDailyChallengeRepository dailyChallengeRepository, ICityService cityService)
        {
            _dailyChallengeRepository = dailyChallengeRepository;
            _cityService = cityService;
            _cityRandomizer = new CityRandomizer();
        }
        public async Task<DailyChallangeDto> GetChallengeForDateAsync(DateOnly date)
        {
            var challenge = await _dailyChallengeRepository.GetChallengeForDate(date);

            if (challenge != null)
            {
                if (challenge.City.IsArchived)
                {
                    throw new ConflictException("This challenge is currently unavailable.");
                }

                return MapToDto(challenge);
            }

            var lastChallenge = await _dailyChallengeRepository.GetLastChallenge();
            var activeCityIds = await _cityService.GetActiveCityIdsAsync();

            // SCRAPPED CODE USED FOR RANDOMIZATION
            // var amountCities = await _cityService.GetCityCountAsync();

            List<int> recentCityIds = new List<int>();

            if (lastChallenge != null)
            {
                recentCityIds.Add(lastChallenge.CityId);
            }

            int? selectedCityId = _cityRandomizer.SelectNextCityId(recentCityIds, activeCityIds);
            
            // SCRAPPED CODE USED FOR RANDOMIZATION
            // int? selectedCityId = _cityRandomizer.SelectNextCityId(recentCityIds, amountCities);

            if (!selectedCityId.HasValue)
            {
                throw new NotFoundException("No cities found.");
            }

            await _dailyChallengeRepository.CreateDailyChallenge(date, selectedCityId.Value);

            var newChallenge = await _dailyChallengeRepository.GetChallengeForDate(date);

            if (newChallenge == null)
            {
                throw new NotFoundException("Could not retrieve the created challenge.");
            }

            return MapToDto(newChallenge);
        }

        private static DailyChallangeDto MapToDto(DailyChallange challenge)
        {
            return new DailyChallangeDto
            {
                CityDetails = new CityDetailsDto
                {
                    CityName = challenge.City.Name,
                    Clues = challenge.City.Clues.Select(c => new ClueDto
                    {
                        ClueText = c.ClueText,
                        PointValue = c.Point
                    }).ToList(),
                    Questions = challenge.City.Questions.Select(q => new QuestionDto
                    {
                        QuestionText = q.QuestionText,
                        Options = q.Options.Select(o => new OptionDto
                        {
                            OptionText = o.OptionText,
                            IsCorrect = o.IsCorrect
                        }).ToList()
                    }).ToList()
                },
                ChallangeDate = challenge.ChallangeDate
            };
        }
    }
}
