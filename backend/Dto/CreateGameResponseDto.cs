namespace Backend.Dto
{
    public class CreateGameResponseDto
    {
        public int GameId { get; set; }
        public List<AchievementDto> NewAchievements { get; set; } = new();
    }
}
