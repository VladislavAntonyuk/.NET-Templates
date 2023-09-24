namespace App1.Application.Configuration.Behaviors;

using Mediator;
using Microsoft.Extensions.Logging;

public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{
	private readonly ILogger<TRequest> logger;

	public UnhandledExceptionBehavior(ILogger<TRequest> logger)
	{
		this.logger = logger;
	}

	public async ValueTask<TResponse> Handle(TRequest request,
		MessageHandlerDelegate<TRequest, TResponse> next,
		CancellationToken cancellationToken)
	{
		try
		{
			return await next(request, cancellationToken);
		}
		catch (Exception ex)
		{
			var requestName = typeof(TRequest).Name;
			logger.LogError(ex, "Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
			throw;
		}
	}
}