namespace Backend.Dto
{
    public class ReusltDto
    {
        public string UserName { get; set; } //This will be either inputted name or extracted from the user's profile
        public int? UserId { get; set; } //Only for logged in users
        public decimal FinalScore { get; set; }
        public int? Streak { get; set; } //This will be calculated based on games with user's id, only avail for logged in users, ie when UserId != null
    }
}
