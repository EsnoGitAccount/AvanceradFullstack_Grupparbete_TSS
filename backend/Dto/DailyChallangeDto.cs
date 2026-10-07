namespace Backend.Dto
{
    public class DailyChallangeDto
    {
        public int Id { get; set; }
        public required CityDetailsDto CityDetails { get; set; }
        public DateOnly ChallangeDate { get; set; }
    }
}
