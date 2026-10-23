using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class OptionUpdateDto
    {
        [Range(1, int.MaxValue)]
        public int OptionId { get; set; }

        [Required]
        public string OptionText { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }
    }
}