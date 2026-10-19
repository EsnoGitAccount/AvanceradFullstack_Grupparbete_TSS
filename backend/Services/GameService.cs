using Backend.Dto;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Backend.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Backend.Exceptions;

namespace Backend.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IDailyChallengeRepository _dailyChallengeRepository;

        private readonly IUserRepository _userRepository;

        public GameService(IGameRepository gameRepository, IDailyChallengeRepository dailyChallengeRepository, IUserRepository userRepository)
        {
            _gameRepository = gameRepository;
            _dailyChallengeRepository = dailyChallengeRepository;
            _userRepository = userRepository;
        }
        public async Task CreateGameAsync(GameDto gameDto)
        {
            var todaysChallenge = await _dailyChallengeRepository.GetChallengeForDate(DateOnly.FromDateTime(DateTime.UtcNow));

            if(todaysChallenge == null)
            {
                throw new InvalidOperationException("No daily challenge found for today.");
            }

            if (todaysChallenge.City.IsArchived)
            {
                throw new ConflictException("This challenge is currently unavailable.");
            }

            var game = MapDtoToGame(gameDto, todaysChallenge.DailyChallangeId);

            var result = await _gameRepository.CreateGameAsync(game);

            if (result != true)
            {
                throw new InvalidOperationException("Failed to create game.");
            }
            else
            {
                return;
            }
        }

        public async Task<IEnumerable<ReusltDto>> GetResultsForDateAsync(DateOnly? date)
        {
            var dateToUse = date ?? DateOnly.FromDateTime(DateTime.UtcNow);

            var gamesForDate = await _gameRepository.GetGamesForDateAsync(dateToUse);
            var topList = gamesForDate
                .OrderByDescending(g => g.TotalScore)
                .ToList();
            
            var results = new List<ReusltDto>();

            //If we have 10 or less results for the date, we will check for streaks for each user
            if (topList.Count() <= 10)
            {
                foreach (var result in gamesForDate)
                {
                    //skip if the userId is null, as we cannot get a streak for a guest user
                    if (result.UserId == null)
                    {
                        results.Add(new ReusltDto
                        {
                            UserName = result.UserName,
                            FinalScore = result.TotalScore,
                            Rank = 0,
                            IsCurrentUser = false,
                        });
                        continue;
                    }
           
                    var currentStreak = await GetStreakForUserAsync(result.UserId.Value);
                    var user = await _userRepository.GetUserByIdAsync(result.UserId.Value);

                    results.Add(new ReusltDto
                    {
                        UserName = user?.UserName ?? result.UserName, 
                        FinalScore = result.TotalScore,
                        Streak = currentStreak,
                        Rank = 0,
                        IsCurrentUser = user?.UserName == "user1", //replace with actual logic for checking if the user is the currently logged in user
                    });
                }
            }

            // If we have more than 10 results for the date,
            // we will only check for streaks for the top 10 results + eventually logged in user
            // This is for performance reasons
            else
            {
                for (int i = 0; i < topList.Count(); i++)
                {
                    var result = topList[i];

                    User? user = null;
                    var isCurrentUser = result.UserName == "user1";

                    if (result.UserId.HasValue)
                    {
                        user = await _userRepository.GetUserByIdAsync(result.UserId.Value);
                        if (user != null)
                        {
                            isCurrentUser = isCurrentUser || user.UserName == "user1";
                        }
                    }

                    if (result.UserId == null || (i >= 10 && !isCurrentUser))
                    {
                        //create result with streak = null and add to results list
                        results.Add(new ReusltDto
                        {
                            UserName = user?.UserName ?? result.UserName,
                            FinalScore = result.TotalScore,
                            Rank = 0,
                            Streak = null,
                            IsCurrentUser = isCurrentUser
                        });
                        continue;
                    }

                    var currentStreak = await GetStreakForUserAsync(result.UserId.Value);

                    results.Add(new ReusltDto
                    {
                        UserName = user?.UserName ?? result.UserName,
                        FinalScore = result.TotalScore,
                        Rank = 0,
                        Streak = currentStreak,
                        IsCurrentUser = isCurrentUser,
                    });
                }
            }

            var completeRanking = results
                .OrderByDescending(r => r.FinalScore)
                .ToList();

            int prevRank = 1;
            decimal prevScore = -1;

            var displayResults = new List<ReusltDto>();

            foreach (var result in completeRanking)
            {
                if (completeRanking.IndexOf(result) > 9 && !result.IsCurrentUser)
                {
                    continue; //Early skip if we are outside of the top 10 and we are not the current user
                }

                if (result.FinalScore != prevScore)
                {
                    prevRank = completeRanking.IndexOf(result) + 1;
                    result.Rank = prevRank;
                    prevScore = result.FinalScore;
                }
                else
                {
                    result.Rank = prevRank;
                }

                displayResults.Add(result);

                if (completeRanking.IndexOf(result) > 9 && result.IsCurrentUser)
                {
                    break; //if we are outside of the top 10 and we have found the current user, we can break out of the loop
                }
            }

            return displayResults;
        }

        private async Task<int> GetStreakForUserAsync(int userId)
        {
            var games = await _gameRepository.GetGamesForUserAsync(userId);
            var orderedGames = games
                .OrderByDescending(g => g.CompletedAt)
                .ToList();

            // TakeWhile grabs the current game, and the index of it in the List 
            // which we ordered above, it then removes 1 day from the previous date and compares it to the current date,
            // if they are equal it will continue to add to the streak until it finds a date that is not equal to the previous date + 1 day
            var currentStreak = orderedGames.
                TakeWhile((game, index) =>
                {
                    if (index == 0)
                    {
                        return true;
                    }

                    var expectedDate = orderedGames[index - 1].CompletedAt.AddDays(-1);
                    return game.CompletedAt == expectedDate;
                })
                .Count();

            return currentStreak;
        }

        private GameDto MapGameToDto (Game game)
        {
            return new GameDto
            {
                UserName = game.UserName,
                UserId = game.UserId,
                IsGuest = game.UserId == null,
                FinalScore = game.TotalScore,
                CompletedAt = game.CompletedAt
            };
        }

        private Game MapDtoToGame (GameDto gameDto, int dailyChallengeId)
        {
            return new Game
            {
                UserName = gameDto.UserName ?? null,
                UserId = gameDto.UserId ?? null,
                TotalScore = (int)gameDto.FinalScore,
                CompletedAt = gameDto.CompletedAt == default(DateOnly) ? DateOnly.FromDateTime(DateTime.UtcNow) : gameDto.CompletedAt,
                DailyChallangeId = dailyChallengeId // This should be bouncing on cache in the future!
            };
        }
    }
}
