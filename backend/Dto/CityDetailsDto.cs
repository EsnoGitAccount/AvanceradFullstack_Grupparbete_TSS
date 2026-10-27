namespace Backend.Dto
{
    public class CityDetailsDto
    {
        public string CityName { get; set; } = string.Empty;
        public List<ClueDto> Clues { get; set; } = [];
        public List<QuestionDto> Questions { get; set; } = [];
        public string? CityPicture {get;set;}
    }
}
