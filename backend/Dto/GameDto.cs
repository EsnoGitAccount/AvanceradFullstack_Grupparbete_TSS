using System.Security.Principal;

namespace Backend.Dto
{
    public class GameDto
    {
        public int Id { get; set; }
        public required UserDto User { get; set; }
        public decimal FinalScore { get; set; }
        public DateOnly CompletedAt { get; set; }
    }
}
