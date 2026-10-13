namespace Backend.Model
{
    public class RefreshToken
    {
        public int RefreshTokenId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public string TokenHash { get; set; } = string.Empty;

        public Guid SessionId { get; set; }

        public DateTimeOffset ExpiresAt { get; set; }

        public DateTimeOffset? RevokedAt { get; set; }
    }
}