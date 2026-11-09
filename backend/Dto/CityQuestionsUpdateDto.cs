using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class CityQuestionsUpdateDto
    {
        [Required]
        public List<ClueUpdateDto> Clues { get; set; } = new();

        [Required]
        public List<QuestionUpdateDto> Questions { get; set; } = new();
    }

    public class CityQuestionsEditDto
    {
        public List<QuestionUpdateDto> Questions { get; set; } = new();
        public List<ClueEditDto> Clues { get; set; } = new();
    }

    public class ClueUpdateDto
    {
        [Range(1, int.MaxValue)]
        public int ClueId { get; set; }
        [Required]
        public string ClueText { get; set; } = string.Empty;
    }

    public class ClueEditDto : ClueUpdateDto
    {
        public decimal Point { get; set; }
    }
}