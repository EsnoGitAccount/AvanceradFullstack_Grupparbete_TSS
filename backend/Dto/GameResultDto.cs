namespace Backend.Dto
{
    public class GameResultDto
    {
        public int GameId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; } = "Guest";
        public int TotalScore { get; set; }
        public DateOnly CompletedAt { get; set; }
        public string CityName { get; set; } = string.Empty;
    }
}