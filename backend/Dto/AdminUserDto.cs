namespace Backend.Dto
{
    public class AdminUserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsArchived { get; set; }
    }
}
