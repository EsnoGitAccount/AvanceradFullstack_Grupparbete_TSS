using Backend.Dto;

namespace Backend.Services
{
    public interface ICookieService
    {
        void SetAuthenticationCookie(HttpResponse response, AuthSessionDto session);
        void DeleteAuthenticationCookie(HttpResponse response);
    }

    public class CookieService : ICookieService
    {
        private const string AccessTokenCookieName = "accessToken";
        private const string RefreshTokenCookieName = "refreshToken";
        private const string AccessTokenCookiePath = "/api";
        private const string RefreshTokenCookiePath = "/api/auth";

        // Store access and refresh tokens in HTTP-only cookies
        public void SetAuthenticationCookie(HttpResponse response, AuthSessionDto session)
        {
            response.Cookies.Append(AccessTokenCookieName, session.AccessToken,
                CreateAuthenticationCookieOptions(session.AccessTokenExpiresAt, AccessTokenCookiePath));

            response.Cookies.Append(RefreshTokenCookieName, session.RefreshToken,
                CreateAuthenticationCookieOptions(session.RefreshTokenExpiresAt, RefreshTokenCookiePath));
        }

        // Remove access and refresh token cookies
        public void DeleteAuthenticationCookie(HttpResponse response)
        {
            response.Cookies.Delete(AccessTokenCookieName,
                CreateDeleteCookieOptions(AccessTokenCookiePath));

            response.Cookies.Delete(RefreshTokenCookieName,
                CreateDeleteCookieOptions(RefreshTokenCookiePath));
        }

        // Configure secure cookie options for authentication tokens
        private static CookieOptions CreateAuthenticationCookieOptions(DateTimeOffset expiresAt, string path)
        {
            return new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Path = path,
                Expires = expiresAt
            };
        }

        // Configure cookie option used when deleting authentication cookies
        private static CookieOptions CreateDeleteCookieOptions(string path)
        {
            return new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Path = path
            };
        }
    }


}
