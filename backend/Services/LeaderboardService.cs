using Backend.Dto;
using Backend.Model;
using Backend.Repositories.IRepositories;
using Backend.Services.IServices;

namespace Backend.Services;

public class LeaderboardService(
    IGameRepository gameRepository,
    IUserRepository userRepository) : ILeaderboardService
{
    public async Task<LeaderboardDto> GetAsync(int? currentUserId, int? gameId)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var games = await gameRepository.GetAllGamesAsync();

        // Registered players receive a streak for each consecutive day they have played, including today.
        // Guestplayers do not receive a streak and are not included in the all-time leaderboard.
        var dailyBest = games
            .Where(g => g.CompletedAt <= today)
            .GroupBy(g => new
            {
                Player = g.UserId.HasValue
                    ? $"user:{g.UserId}"
                    : $"guest:{g.GameId}",
                Date = g.CompletedAt
            })
            .Select(group => group
                .OrderByDescending(g => g.TotalScore)
                .ThenBy(g => g.GameId)
                .First())
            .ToList();

        var streaks = dailyBest
            .Where(g => g.UserId.HasValue)
            .GroupBy(g => g.UserId!.Value)
            .ToDictionary(
                group => group.Key,
                group => CalculateStreak(
                    group.Select(g => g.CompletedAt),
                    today));

        var dailyResults = Rank(
            dailyBest
                .Where(g => g.CompletedAt == today)
                .Select(g =>
                {
                var result = CreateResult(
                    g,
                    g.TotalScore,
                    currentUserId,
                    streaks);

                    if (!currentUserId.HasValue && 
                    g.UserId == null &&
                    gameId.HasValue && 
                    g.GameId == gameId.Value)
                    
                    {
                        result.IsCurrentUser = true;
                    }
                    
                    return result;
                }));

        ResultDto? currentGuestResult = !currentUserId.HasValue
            ? dailyResults.FirstOrDefault(r => r.IsCurrentUser)
            : null;

        if (currentUserId == null && gameId.HasValue)
        {
            var guestGame = dailyBest
                .FirstOrDefault(g => g.GameId == gameId.Value);
            if (guestGame != null)
            {
                var guestRank = 1 + dailyResults
                    .Count(r => r.FinalScore > guestGame.TotalScore);
            }
        }

        // Guests are not included in the all-time leaderboard, only registered players.
        var allTimeResults = Rank(
            dailyBest
                .Where(g => g.UserId.HasValue)
                .GroupBy(g => g.UserId!.Value)
                .Select(group => CreateResult(
                    group.First(),
                    group.Sum(g => (decimal)g.TotalScore),  
                    currentUserId,
                    streaks)));

        PlayerStatisticsDto? currentUser = null;

        if (currentUserId.HasValue)
        {
            var user = await userRepository
                .GetUserByIdAsync(currentUserId.Value);

            if (user != null)
            {
                var daily = dailyResults
                    .FirstOrDefault(r => r.IsCurrentUser);

                var allTime = allTimeResults
                    .FirstOrDefault(r => r.IsCurrentUser);

                currentUser = new PlayerStatisticsDto
                {
                    UserName = user.UserName ?? "",
                    Streak = streaks.GetValueOrDefault(
                        currentUserId.Value),
                    DailyScore = daily?.FinalScore,
                    DailyRank = daily?.Rank,
                    AllTimeScore = allTime?.FinalScore ?? 0,
                    AllTimeRank = allTime?.Rank
                };
            }
        }

        return new LeaderboardDto
        {
            Date = today,

            DailyCount = dailyResults.Count,
            AllTimeCount = allTimeResults.Count,

            DailyTop10 = dailyResults.Take(10).ToList(),
            AllTimeTop10 = allTimeResults.Take(10).ToList(),
            CurrentUser = currentUser,

            CurrentGuestResult = currentGuestResult
        };
    }

    private static ResultDto CreateResult(
        Game game,
        decimal score,
        int? currentUserId,
        Dictionary<int, int> streaks)
    {
        return new ResultDto
        {
            UserName = game.User?.UserName
                ?? game.UserName
                ?? "Guest",

            FinalScore = score,

            Streak = game.UserId.HasValue
                ? streaks.GetValueOrDefault(game.UserId.Value)
                : null,

            IsCurrentUser = currentUserId.HasValue
                && game.UserId == currentUserId.Value
        };
    }

    private static List<ResultDto> Rank(
        IEnumerable<ResultDto> results)
    {
        var sorted = results
            .OrderByDescending(r => r.FinalScore)
            .ThenBy(r => r.UserName, StringComparer.Ordinal)
            .ToList();

        var rank = 0;
        decimal? previousScore = null;

        for (var i = 0; i < sorted.Count; i++)
        {
            if (sorted[i].FinalScore != previousScore)
            {
                rank = i + 1;
            }

            sorted[i].Rank = rank;
            previousScore = sorted[i].FinalScore;            
        }

        return sorted;
    }

    private static int CalculateStreak(
        IEnumerable<DateOnly> playedDates,
        DateOnly today)
    {
        var dates = playedDates.ToHashSet();

        var date = dates.Contains(today)
            ? today
            : today.AddDays(-1);

        var streak = 0;

        while (dates.Contains(date))
        {
            streak++;
            date = date.AddDays(-1);
        }

        return streak;
    }
}