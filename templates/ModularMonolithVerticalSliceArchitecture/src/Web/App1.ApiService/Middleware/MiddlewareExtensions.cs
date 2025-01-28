namespace App1.ApiService.Middleware;

internal static class MiddlewareExtensions
{
	internal static IApplicationBuilder UseLogContext(this IApplicationBuilder app)
	{
		app.UseMiddleware<LogContextTraceLoggingMiddleware>();

		return app;
	}
}