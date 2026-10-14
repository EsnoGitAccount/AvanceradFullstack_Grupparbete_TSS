namespace Backend.Dto
{
    public class QuestionDto
    {
        public string QuestionText { get; set; } = string.Empty;
        public List<OptionDto> Options { get; set; } = [];
    }
}
