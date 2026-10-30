using Backend.Model;

namespace Backend.Dto
{
    public class UserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = [];
        public List<AchievementDto> Achievements { get; set; } = [];

        public UserDto(User user, IList<string>? roles = null)
        {
            Username = user.UserName;
            Email = user.Email;

            Achievements = user.Achievements
                .OrderBy(a => a.AchievementId)
                .Select(a => new AchievementDto(a))
                .ToList();
        }
    }
}
