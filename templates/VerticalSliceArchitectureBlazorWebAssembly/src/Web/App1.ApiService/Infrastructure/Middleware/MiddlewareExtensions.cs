namespace App1.ApiService.Infrastructure.Middleware;

internal static class MiddlewareExtensions
{
	internal static IApplicationBuilder UseLogContext(this IApplicationBuilder app)
	{
		app.UseMiddleware<LogContextTraceLoggingMiddleware>();

		return app;
	}
}