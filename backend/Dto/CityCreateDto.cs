using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class CityCreateDto
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public IFormFile CityPicture { get; set; } = null!;
    }
}
