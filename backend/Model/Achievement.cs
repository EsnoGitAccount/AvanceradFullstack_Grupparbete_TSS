using System.Text.Json.Serialization;

namespace Backend.Model
{
    public class Achievement
    {
        public int AchievementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public string? ImageUrl { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
