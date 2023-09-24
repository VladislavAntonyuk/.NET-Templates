namespace App1.Application.Configuration.Behaviors;

using Mediator;
using Microsoft.Extensions.Logging;

public class LoggingBehavior<TRequest, TResponse> : MessagePreProcessor<TRequest, TResponse> where TRequest : IMessage
{
	private readonly ILogger<TRequest> logger;

	public LoggingBehavior(ILogger<TRequest> logger)
	{
		this.logger = logger;
	}

	protected override ValueTask Handle(TRequest message, CancellationToken cancellationToken)
	{
		var requestName = typeof(TRequest).Name;
		logger.LogInformation("Request: {Name} {@Request}", requestName, message);
		return ValueTask.CompletedTask;
	}
}