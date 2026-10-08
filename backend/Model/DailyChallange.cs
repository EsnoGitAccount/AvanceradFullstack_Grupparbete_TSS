namespace Backend.Model
{
    public class DailyChallange
    {
        public int DailyChallangeId { get; set; }
        public int CityId { get; set; }
        public City City { get; set; } = null!;
        public DateOnly ChallangeDate { get; set; }
    }
}
