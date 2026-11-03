namespace Backend.Model
{
    public class Achievement
    {
        public int AchievementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageKey { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
