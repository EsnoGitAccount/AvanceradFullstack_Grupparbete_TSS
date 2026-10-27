using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string CityPicture { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Clue> Clues { get; set; } = new List<Clue>();
        public bool IsArchived { get; set; } = false;
    }

}
