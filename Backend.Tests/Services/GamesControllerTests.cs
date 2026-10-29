using System.Security.Claims;
using Backend.Controllers;
using Backend.Dto;
using Backend.Services.IServices;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Moq;

namespace Backend.Tests.Services
{
    public class GamesControllerTests
    {
        private readonly Mock<IGameService> _service = new();
        private readonly GamesController _controller;

        public GamesControllerTests()
        {
            _controller = new GamesController(_service.Object, new EphemeralDataProtectionProvider())
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            _controller.Request.Scheme = "https";
        }

        [Fact]
        public async Task PostGame_GuestAlredyPlayed_Returns409WithoutSaving()
        {
            _controller.Request.Headers.Cookie = "GuestDailyGameLimit=today-cookie";

            _service.Setup(s => s.GuestUserHasPlayedToday("today-cookie")).Returns(true);

            var result = await _controller.PostGame(new GameDto());

            var response = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status409Conflict, response.StatusCode);

            _service.Verify(s => s.CreateGameAsync(It.IsAny<GameDto>()), Times.Never);

            Assert.False(_controller.Response.Headers.ContainsKey(HeaderNames.SetCookie));
        }

        [Fact]
        public async Task PostGame_NewGuest_SavesAndSetsProtectedCookie()
        {
            _service.Setup(s => s.CreateGameAsync(It.IsAny<GameDto>())).ReturnsAsync(42);

            _service.Setup(s => s.CreatedGuestPlayedCookie()).Returns("protected-cookie");

            var dto = new GameDto
            {
                UserId = 999,
                IsGuest = false,
                UserName = "Guest",
            };

            var result = await _controller.PostGame(dto);

            Assert.IsType<OkObjectResult>(result);

            _service.Verify(s => s.CreateGameAsync(It.Is<GameDto>(g =>
                g.UserId == null &&
                g.IsGuest &&
                g.UserName == "Guest")),
            Times.Once);

            var cookie = SetCookieHeaderValue.Parse(
            _controller.Response.Headers["Set-Cookie"].ToString());

            Assert.Equal("GuestDailyGameLimit", cookie.Name.ToString());
            Assert.Equal("protected-cookie", cookie.Value.ToString());
            Assert.True(cookie.HttpOnly);
            Assert.True(cookie.Secure);
            Assert.Equal(
                Microsoft.Net.Http.Headers.SameSiteMode.Lax,
                cookie.SameSite);
            Assert.Equal("/", cookie.Path.ToString());
        }
    }
}
