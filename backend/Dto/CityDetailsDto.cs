namespace Backend.Dto
{
    public class CityDetailsDto
    {
        public int CityId { get; set; }
        public List<ClueDto> Clues { get; set; } = [];
        public List<QuestionDto> Questions { get; set; } = [];
    }
}
