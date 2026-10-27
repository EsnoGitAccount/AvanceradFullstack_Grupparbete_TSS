using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class CityDto
    {
        public int CityId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        public string CityPicture { get; set; } = null!;
        public bool IsArchived { get; set; }
    }
}
