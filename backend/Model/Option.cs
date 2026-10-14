namespace Backend.Model
{
    public class Option
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
    }
}
