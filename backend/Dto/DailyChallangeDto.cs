using Backend.Model;

namespace Backend.Dto
{
    public class DailyChallangeDto
    {
        public required CityDetailsDto CityDetails { get; set; }
        public DateOnly ChallangeDate { get; set; }
    }
}
