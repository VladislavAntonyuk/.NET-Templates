namespace App1.Application.Configuration.Behaviors;

using System.Diagnostics;
using Mediator;
using Microsoft.Extensions.Logging;

public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{
	private readonly ILogger<TRequest> logger;
	private readonly Stopwatch timer;

	public PerformanceBehavior(ILogger<TRequest> logger)
	{
		timer = new Stopwatch();

		this.logger = logger;
	}

	public async ValueTask<TResponse> Handle(TRequest request,
		MessageHandlerDelegate<TRequest, TResponse> next,
		CancellationToken cancellationToken)
	{
		timer.Start();

		var response = await next(request, cancellationToken);

		timer.Stop();

		var elapsedMilliseconds = timer.ElapsedMilliseconds;

		if (elapsedMilliseconds > 1000)
		{
			var requestName = typeof(TRequest).Name;
			logger.LogWarning("Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
							  requestName, elapsedMilliseconds, request);
		}

		return response;
	}
}