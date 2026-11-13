using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class ChangeUsernameDto
    {
        [Required]
        public string NewUsername { get; set; } = string.Empty;
    }
}
