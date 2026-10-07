namespace Backend.Model
{
    public class Game
    {
        public int GameId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int DailyChallangeId { get; set; }
        public DailyChallange DailyChallange { get; set; } = null!;
        public int TotalScore { get; set; }
        public DateOnly CompletedAt { get; set; }
    }
}
