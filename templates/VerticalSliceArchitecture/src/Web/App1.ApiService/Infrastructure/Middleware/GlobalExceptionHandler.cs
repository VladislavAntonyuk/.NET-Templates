namespace App1.ApiService.Infrastructure.Middleware;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
	public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
		Exception exception,
		CancellationToken cancellationToken)
	{
		logger.LogError(exception, "Unhandled exception occurred");

		var problemDetails = new ProblemDetails
		{
			Status = StatusCodes.Status500InternalServerError,
			Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
			Title = "Server failure"
		};

		httpContext.Response.StatusCode = problemDetails.Status.Value;

		await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

		return true;
	}
}