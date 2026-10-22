namespace Backend.Dto
{
    public class PlayerStatisticsDto
    {
        public string UserName { get; set; } = null!;
        public int Streak { get; set; }

        public decimal? DailyScore { get; set; }
        public int? DailyRank { get; set; }

        public decimal AllTimeScore { get; set; }
        public int? AllTimeRank { get; set; }
    }
}
