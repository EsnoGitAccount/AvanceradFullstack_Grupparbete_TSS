using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class CityQuestionsUpdateDto
    {
        [Required]
        public List<QuestionUpdateDto> Questions { get; set; } = new();
    }
}