namespace Backend.Dto
{
    public class AuthSessionDto
    {
        public required UserDto User { get; init; }

        public required string AccessToken { get; init; }

        public required string RefreshToken { get; init; }

        public DateTimeOffset AccessTokenExpiresAt { get; init; }

        public DateTimeOffset RefreshTokenExpiresAt { get; init; }
    }
}