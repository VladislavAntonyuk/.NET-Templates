namespace App1.Application.Configuration.Behaviors;

using Interfaces.CQRS;
using Mediator;
using Microsoft.Extensions.Logging;

public sealed class UnhandledExceptionBehavior<TRequest, TResponse>
	(ILogger<TRequest> logger) : MessageExceptionHandler<TRequest, TResponse> where TRequest : IMessage where TResponse : OperationResult, new()
{
	protected override ValueTask<ExceptionHandlingResult<TResponse>> Handle(TRequest request, Exception exception, CancellationToken cancellationToken)
	{
		var result = new TResponse
		{
			Errors =
			{
				new()
				{
					Description = exception.Message
				}
			}
		};
		var requestName = typeof(TRequest).Name;
		logger.LogError(exception, "Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
		return ValueTask.FromResult(ExceptionHandlingResult<TResponse>.Handled(result));
	}
}