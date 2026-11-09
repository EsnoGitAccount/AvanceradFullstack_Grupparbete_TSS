using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class CityQuestionsUpdateDto
    {
        public int ClueCount { get; set; }
        public List<ClueUpdateDto>? Clues { get; set; }

        [Required]
        public List<QuestionUpdateDto> Questions { get; set; } = new();
    }

    public class ClueUpdateDto
    {
        [Range(1, int.MaxValue)]
        public int ClueId { get; set; }
        [Required]
        public string ClueText { get; set; } = string.Empty;
        public decimal Point { get; set; }
    }
}