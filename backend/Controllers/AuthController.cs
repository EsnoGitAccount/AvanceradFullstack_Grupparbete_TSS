using Backend.Dto;
using Backend.Exceptions;
using Backend.Services;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using static System.Collections.Specialized.BitVector32;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private const string RefreshTokenCookieName = "refreshToken";
        private const string CsrfRequestCookieName = "XSRF-TOKEN";

        private readonly IAuthService _authService;
        private readonly IAntiforgery _antiforgery;
        private readonly ICookieService _cookieService;
        private readonly IWebHostEnvironment _environment;

        public AuthController(IAuthService authService, IAntiforgery antiforgery, ICookieService cookieService, IWebHostEnvironment environment)
        {
            _authService = authService;
            _antiforgery = antiforgery;
            _cookieService = cookieService;
            _environment = environment;
        }

        // Generate a CSRF token and make it available to the frontend
        [HttpGet("csrf")]
        [AllowAnonymous]
        public IActionResult GetCsrfToken()
        {
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);

            Response.Cookies.Append(
                CsrfRequestCookieName,
                tokens.RequestToken!,

                new CookieOptions
                {
                    HttpOnly = false,
                    Secure = true,
                    SameSite = SameSiteMode.None,
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

            _cookieService.SetAuthenticationCookie(Response, session);

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

            _cookieService.SetAuthenticationCookie(Response, session);

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

            _cookieService.DeleteAuthenticationCookie(Response);

            return NoContent();
        }


        [HttpPost("register")]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var session = await _authService.RegisterAsync(registerDto);

            _cookieService.SetAuthenticationCookie(Response, session);
            return Ok(session.User);
        }

	}
}
