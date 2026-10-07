using Backend.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _requestDelegate;
		private readonly ILogger<ExceptionMiddleware> _logger;
		private readonly IProblemDetailsService _problemDetailsService;


		public ExceptionMiddleware(RequestDelegate requestDelegate,
			ILogger<ExceptionMiddleware> logger,
			IProblemDetailsService problemDetailsService)
		{
			_requestDelegate = requestDelegate;
			_logger = logger;
			_problemDetailsService = problemDetailsService;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _requestDelegate(context);
			}
			catch (Exception ex)
			{
				context.Response.StatusCode = ex switch
				{
					AppValidationException => StatusCodes.Status400BadRequest,
					ConflictException => StatusCodes.Status409Conflict,
					NotFoundException => StatusCodes.Status404NotFound,
					UnauthorizedException => StatusCodes.Status401Unauthorized,
					_ => StatusCodes.Status500InternalServerError
				};

				if (context.Response.StatusCode >= 500)
				{
					_logger.LogError(ex, "An unhandled exception occurred.");
				}
				else
				{
					_logger.LogWarning("Request failed with status {StatusCode}: {Message}", context.Response.StatusCode, ex.Message);
				}


				await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
				{
					HttpContext = context,
					Exception = ex,

					ProblemDetails = new ProblemDetails
					{
						Status = context.Response.StatusCode,
						Type = ex.GetType().Name,
						Title = "An error occurred while processing your request.",
						Detail = context.Response.StatusCode >= 500 ? "An unexpected error occurred." : ex.Message
					}

				});
			}
		}
	}
}
