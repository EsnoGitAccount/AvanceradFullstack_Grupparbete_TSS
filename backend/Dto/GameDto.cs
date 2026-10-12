using System.Security.Principal;

namespace Backend.Dto
{
    public class GameDto
    {
        //For now just use UserName, it is unique in logged in users,
        //but in the future we might want to use a more robust user identifier, potentially claim from frontend
        public string? UserName { get; set; } = null!;
        public int? UserId { get; set; }
        public bool IsGuest { get; set; }
        public decimal FinalScore { get; set; }
        public DateOnly CompletedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
