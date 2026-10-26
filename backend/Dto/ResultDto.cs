namespace Backend.Dto
{
    public class ResultDto
    {
        public string UserName { get; set; } //This will be either inputted name or extracted from the user's profile
        public decimal FinalScore { get; set; }
        public int Rank { get; set; } //This will be calculated based on the final score
        public int? Streak { get; set; } //This will be calculated based on games with user's id, only avail for logged in users, ie when UserId != null
        public bool IsCurrentUser { get; set; } //This will be true if the result belongs to the current user, false otherwise
    }
}
