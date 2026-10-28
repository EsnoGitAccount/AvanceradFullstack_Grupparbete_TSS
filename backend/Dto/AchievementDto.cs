using Backend.Model;

namespace Backend.Dto
{
    public class AchievementDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public AchievementDto(Achievement achievement)
        {
            Name = achievement.Name;
            Description = achievement.Description;
        }
    }
}
