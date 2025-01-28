namespace App1.ApiService.Middleware;

using System.Diagnostics;

internal sealed class LogContextTraceLoggingMiddleware(RequestDelegate next)
{
	public Task Invoke(HttpContext context, ILogger<LogContextTraceLoggingMiddleware> logger)
	{
		var traceId = Activity.Current?.TraceId.ToString();

		using (logger.BeginScope("TraceId {traceId}", traceId))
		{
			return next.Invoke(context);
		}
	}
}