namespace Backend.Dto
{
    public class LeaderboardDto
    {        public DateOnly Date { get; set; }
        public List<ResultDto> DailyTop10 { get; set; } = [];
        public List<ResultDto> AllTimeTop10 { get; set; } = [];
        public PlayerStatisticsDto? CurrentUser { get; set; }
    }
}
