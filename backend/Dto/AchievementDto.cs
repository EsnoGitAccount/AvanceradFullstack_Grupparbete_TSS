using Backend.Model;

namespace Backend.Dto
{
    public class AchievementDto
    {
        public int AchievementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public AchievementDto(Achievement achievement)
        {
            AchievementId = achievement.AchievementId;
            Name = achievement.Name;
            Description = achievement.Description;
        }
    }
}
