using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
	public class CityUpdateDto
	{
		[Required]
		[MaxLength(100)]
		public string Name { get; set; } = null!;

		public IFormFile? CityPicture { get; set; }
	}
}
