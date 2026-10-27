using Backend.Dto;

namespace Backend.Services.IServices;

public interface ILeaderboardService
{
    Task<LeaderboardDto> GetAsync(int? currentUserId, int? gameId);
}