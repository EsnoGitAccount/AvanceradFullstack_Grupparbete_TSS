using Backend.Dto;

namespace Backend.Services.IServices
{
    public interface IDailyChallengeService
    {
        Task<DailyChallangeDto> GetChallengeForDateAsync(DateOnly date);
    }
}
