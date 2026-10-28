using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Backend.Model
{
    public class User : IdentityUser<int>
    {
        public bool IsArchived { get; set; }

        public decimal TotalScore { get; set; }
        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }

        public List<Achievement> Achievements { get; set; } = new List<Achievement>();
    }
}
