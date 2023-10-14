namespace App1.Application.Configuration.Behaviors;

using Mediator;
using Microsoft.Extensions.Logging;

public class LoggingBehavior<TRequest, TResponse>(ILogger<TRequest> logger) : MessagePreProcessor<TRequest, TResponse>
	where TRequest : IMessage
{
	protected override ValueTask Handle(TRequest message, CancellationToken cancellationToken)
	{
		var requestName = typeof(TRequest).Name;
		logger.LogInformation("Request: {Name} {@Request}", requestName, message);
		return ValueTask.CompletedTask;
	}
}