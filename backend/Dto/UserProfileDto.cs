namespace Backend.Dto
{
    public class UserProfileDto
    {
        public string Username { get; set; } = string.Empty;
        public int CurrentStreak { get; set; }
        public decimal? DailyScore { get; set; }
        public decimal AllTimeScore { get; set; }
        public List<AchievementDto> Achievements { get; set; } = [];
    }
}
