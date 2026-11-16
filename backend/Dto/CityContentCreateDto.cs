using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class CityContentCreateDto
    {
        [Required, MinLength(2), MaxLength(2)]
        public List<QuestionCreateDto> Questions { get; set; } = new();

        [Required, MinLength(5), MaxLength(5)]
        public List<string> Clues { get; set; } = new();
    }

    public class QuestionCreateDto
    {
        [Required]
        public string QuestionText { get; set; } = string.Empty;

        [Required, MinLength(4), MaxLength(4)]
        public List<OptionCreateDto> Options { get; set; } = new();
    }

    public class OptionCreateDto
    {
        [Required]
        public string OptionText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}
