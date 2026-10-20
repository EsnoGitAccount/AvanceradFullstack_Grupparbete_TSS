using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class QuestionUpdateDto
    {
        [Range(1, int.MaxValue)]
        public int QuestionId { get; set; }

        [Required]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        public List<OptionUpdateDto> Options { get; set; } = new();
    }
}