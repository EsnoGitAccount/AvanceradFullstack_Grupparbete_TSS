using Backend.Dto;
using Backend.Exceptions;
using Backend.Services;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private const string AccessTokenCookieName = "accessToken";
        private const string RefreshTokenCookieName = "refreshToken";
        private const string CsrfRequestCookieName = "XSRF-TOKEN";

        private const string AccessTokenCookiePath = "/api";
        private const string RefreshTokenCookiePath = "/api/auth";

        private readonly IAuthService _authService;
        private readonly IAntiforgery _antiforgery;

        public AuthController(IAuthService authService, IAntiforgery antiforgery)
        {
            _authService = authService;
            _antiforgery = antiforgery;
        }

        // Generate a CSRF token and make it available to the frontend
        [HttpGet("csrf")]
        [AllowAnonymous]
        public IActionResult GetCsrfToken()
        {
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);

            Response.Cookies.Append(CsrfRequestCookieName, tokens.RequestToken!,

                new CookieOptions
                {
                    HttpOnly = false,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    Path = "/"
                });

            return NoContent();
        }

        // Authenticate a user and create an authenticated session
        [HttpPost("login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var session = await _authService.LoginAsync(loginDto);

            SetAuthenticationCookies(session);

            return Ok(session.User);
        }

        // Get the currently authenticated users information
        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdClaim, NumberStyles.None, CultureInfo.InvariantCulture, out var userId))
            {
                throw new UnauthorizedException("Invalid authenticated user.");
            }

            var user = await _authService.GetCurrentUserAsync(userId);

            return Ok(user);
        }

        // Refresh the authentication session using the refresh token
        [HttpPost("refresh")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserDto>> Refresh()
        {
            Request.Cookies.TryGetValue(RefreshTokenCookieName, out var refreshToken);

            var session = await _authService.RefreshAsync(refreshToken ?? string.Empty);

            SetAuthenticationCookies(session);

            return Ok(session.User);
        }

        // Log out the user and remove authentication cookies
        [HttpPost("logout")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            Request.Cookies.TryGetValue(RefreshTokenCookieName, out var refreshToken);

            await _authService.LogoutAsync(refreshToken);

            DeleteAuthenticationCookies();

            return NoContent();
        }

        // Store access and refresh tokens in HTTP-only cookies
        private void SetAuthenticationCookies(AuthSession session)
        {
            Response.Cookies.Append(AccessTokenCookieName, session.AccessToken,
                CreateAuthenticationCookieOptions(session.AccessTokenExpiresAt, AccessTokenCookiePath));

            Response.Cookies.Append(RefreshTokenCookieName, session.RefreshToken,
                CreateAuthenticationCookieOptions(session.RefreshTokenExpiresAt, RefreshTokenCookiePath));
        }

        // Remove access and refresh token cookies
        private void DeleteAuthenticationCookies()
        {
            Response.Cookies.Delete(AccessTokenCookieName,
                CreateDeleteCookieOptions(AccessTokenCookiePath));

            Response.Cookies.Delete(RefreshTokenCookieName,
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
