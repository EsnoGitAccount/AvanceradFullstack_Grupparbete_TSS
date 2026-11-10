using Backend.Dto;
using Backend.Exceptions;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Backend.Services.IServices;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;


namespace Backend.Services
{
	public class GameService : IGameService
	{
		private readonly IGameRepository _gameRepository;
		private readonly IDailyChallengeRepository _dailyChallengeRepository;
		private readonly IUserRepository _userRepository;
		private readonly IDataProtector _guestCookieProtector;
		private readonly IAchievementService _achievementService;

		public GameService(IGameRepository gameRepository, IDailyChallengeRepository dailyChallengeRepository, IUserRepository userRepository, IDataProtectionProvider protectionProvider, IAchievementService achievementService)
		{
			_gameRepository = gameRepository;
			_dailyChallengeRepository = dailyChallengeRepository;
			_userRepository = userRepository;
			_guestCookieProtector = protectionProvider.CreateProtector("GuestDailyGameLimit");
			_achievementService = achievementService;
		}
		public async Task<CreateGameResponseDto> CreateGameAsync(GameDto gameDto)
		{
			var todaysChallenge = await _dailyChallengeRepository.GetChallengeForDate(DateOnly.FromDateTime(DateTime.UtcNow));

			if (todaysChallenge == null)
			{
				throw new InvalidOperationException("No daily challenge found for today.");
			}

			if (todaysChallenge.City.IsArchived)
			{
				throw new ConflictException("This challenge is currently unavailable.");
			}

			if (gameDto.UserId.HasValue)
			{
				var hasPlayed = await _gameRepository.HasUserPlayedDailyChallengeAsync(gameDto.UserId.Value, todaysChallenge.DailyChallangeId);

				if (hasPlayed)
				{
					throw new ConflictException("User has already played today's challenge.");
				}
			}


			var game = MapDtoToGame(gameDto, todaysChallenge.DailyChallangeId);

			var createdGame = await _gameRepository.CreateGameAsync(game);

			// TODO: Handle DbUpdateException when the unique index
			// IX_Games_UserId_DailyChallangeId is violated by concurrent requests.
			// Return HTTP 409 Conflict instead of 500 Internal Server Error.

			var saved = await _gameRepository.SaveChangesAsync();

			if (!saved)
			{
				throw new InvalidOperationException("Failed to create game.");
			}

            var newAchievements = new List<AchievementDto>();

            if (game.UserId.HasValue)
            {
                var user = await _userRepository.GetUserByIdAsync(
                    game.UserId.Value);

                if (user != null)
                {
                    await SetStreakForUserAsync(user);

                    var games = await _gameRepository.GetGamesForUserAsync(user.Id);
                    user.TotalScore = games.Sum(g => g.TotalScore);

                    var hasVisitedMora = todaysChallenge.City.Name == "Mora";

                    newAchievements = await _achievementService
                        .CheckAchievementsAsync(user, hasVisitedMora);

                    await _gameRepository.SaveChangesAsync();
                }
            }

            return new CreateGameResponseDto
            {
                GameId = createdGame.GameId,
                NewAchievements = newAchievements
            };
        }

		public async Task<IEnumerable<GameResultDto>> GetGameResultsAsync()
		{
			var games = await _gameRepository.GetAllGamesAsync();

			return games.Select(game => new GameResultDto
			{
				GameId = game.GameId,
				UserId = game.UserId,
				UserName = game.UserName ?? "Guest",
				TotalScore = game.TotalScore,
				CompletedAt = game.CompletedAt,
				CityName = game.DailyChallange.City.Name
			});
		}

		public async Task DeleteGameResultAsync(int gameId)
		{
			var game = await _gameRepository.GetGameByIdAsync(gameId) ??
				throw new NotFoundException("Game result not found");

			_gameRepository.DeleteGame(game);
			
			var result = await _gameRepository.SaveChangesAsync();

			if (!result)
			{
				throw new InvalidOperationException("Failed to delete game result");
			}
		}

		public async Task<IEnumerable<ResultDto>> GetResultsForDateAsync(DateOnly? date, int? currentUserId)
		{
			var dateToUse = date ?? DateOnly.FromDateTime(DateTime.UtcNow);

			var gamesForDate = await _gameRepository.GetGamesForDateAsync(dateToUse);
			var topList = gamesForDate
				.OrderByDescending(g => g.TotalScore)
				.ToList();

			var results = new List<ResultDto>();

			//If we have 10 or less results for the date, we will check for streaks for each user
			if (topList.Count() <= 10)
			{
				foreach (var result in gamesForDate)
				{
					//skip if the userId is null, as we cannot get a streak for a guest user
					if (result.UserId == null)
					{
						results.Add(new ResultDto
						{
							UserName = result.UserName,
							FinalScore = result.TotalScore,
							Rank = 0,
							IsCurrentUser = false,
						});
						continue;
					}

					var user = await _userRepository.GetUserByIdAsync(result.UserId.Value);

					results.Add(new ResultDto
					{
						UserName = user?.UserName ?? result.UserName,
						FinalScore = result.TotalScore,
						Streak = user.CurrentStreak,
						Rank = 0,
						IsCurrentUser = user?.Id == currentUserId
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

					if (result.UserId.HasValue)
					{
						user = await _userRepository.GetUserByIdAsync(result.UserId.Value);
					}

					if (result.UserId == null || (i >= 10 && result.UserId != currentUserId))
					{
						//create result with streak = null and add to results list
						results.Add(new ResultDto
						{
							UserName = user?.UserName ?? result.UserName,
							FinalScore = result.TotalScore,
							Rank = 0,
							Streak = null,
							IsCurrentUser = result.UserId == currentUserId
						});
						continue;
					}


					results.Add(new ResultDto
					{
						UserName = user?.UserName ?? result.UserName,
						FinalScore = result.TotalScore,
						Rank = 0,
						Streak = user.CurrentStreak,
						IsCurrentUser = result.UserId == currentUserId
					});
				}
			}

			var completeRanking = results
				.OrderByDescending(r => r.FinalScore)
				.ToList();

			int prevRank = 1;
			decimal prevScore = -1;

			var displayResults = new List<ResultDto>();

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

        public bool GuestUserHasPlayedToday(string? cookie)
        {

			if (string.IsNullOrEmpty(cookie))
			{
				return false;
			}
			try
			{
				var today = DateTimeOffset.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

				return _guestCookieProtector.Unprotect(cookie) == today;
			}
			catch
			{
				// If unprotecting or parsing fails, we assume the guest has played today.
				return true;
			}
		}

		public string CreatedGuestPlayedCookie()
		{
			var today = DateTimeOffset.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

			return _guestCookieProtector.Protect(today);
		}

        private async Task<bool> DidUserPlayYesterdayAsync(User user)
        {
            var playedYesterday = await _gameRepository.GetUserPlayedYesterdayAsync(user.Id);

            if (!playedYesterday)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task SetStreakForUserAsync(User user)
        {
            var playedYesterday = await DidUserPlayYesterdayAsync(user);

            if(playedYesterday == true)
            {
                await _userRepository.UpdateUserStreakAsync(user, user.CurrentStreak+1);
            }
            else
            {
                await _userRepository.UpdateUserStreakAsync(user, 1);
            }
        }

		//Please note that is not used in the current implementation,probably we can remove it?
		private GameDto MapGameToDto(Game game)
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
		public async Task<bool> HasUserPlayedDailyChallengeAsync(int userId, DateOnly date)
		{
			var dailyChallenge = await _dailyChallengeRepository.GetChallengeForDate(date);

			if (dailyChallenge == null)
			{
				return false;
			}

			return await _gameRepository.HasUserPlayedDailyChallengeAsync(userId, dailyChallenge.DailyChallangeId);


		}

		private static Game MapDtoToGame(GameDto gameDto, int dailyChallengeId)
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
