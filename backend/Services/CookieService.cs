using Backend.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

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

        private readonly IWebHostEnvironment _environment;

        public CookieService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

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
        private CookieOptions CreateAuthenticationCookieOptions(DateTimeOffset expiresAt, string path)
        {
            var isDevelopment = _environment.IsDevelopment();

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
        private CookieOptions CreateDeleteCookieOptions(string path)
        {
            var isDevelopment = _environment.IsDevelopment();

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