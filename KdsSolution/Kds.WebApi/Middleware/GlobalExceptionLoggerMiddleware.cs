using Kds.WebApi.Models;
using System.Net;

namespace Kds.WebApi.Middleware
{
	public class GlobalExceptionLoggerMiddleware
	{
		private readonly ILogger<GlobalExceptionLoggerMiddleware> _logger;
		private readonly RequestDelegate _next;

		public GlobalExceptionLoggerMiddleware(RequestDelegate next, ILogger<GlobalExceptionLoggerMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);

				var exceptionModel = new ExceptionResponseApiModel(ex);
				httpContext.Response.ContentType = "application/json";
				httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				await httpContext.Response.WriteAsJsonAsync(exceptionModel);
			}
		}
	}

	public static class GlobalExceptionLoggerMiddlewareExtensions
	{
		public static IApplicationBuilder UseGlobalExceptionLoggerMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<GlobalExceptionLoggerMiddleware>();
		}
	}
}
