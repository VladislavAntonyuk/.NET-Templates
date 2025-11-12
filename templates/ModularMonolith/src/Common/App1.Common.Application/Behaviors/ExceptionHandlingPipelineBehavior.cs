using Mediator;

namespace App1.Common.Application.Behaviors;

using Exceptions;
using Microsoft.Extensions.Logging;

internal sealed class ExceptionHandlingPipelineBehavior<TRequest, TResponse>(
	ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> logger)
	: IPipelineBehavior<TRequest, TResponse> where TRequest : class, IMessage
{
	public async ValueTask<TResponse> Handle(TRequest message,
		MessageHandlerDelegate<TRequest, TResponse> next,
		CancellationToken cancellationToken)
	{
		try
		{
			return await next(message, cancellationToken);
		}
		catch (Exception exception)
		{
			logger.LogError(exception, "Unhandled exception for {RequestName}", typeof(TRequest).Name);

			throw new App1Exception(typeof(TRequest).Name, innerException: exception);
		}
	}
}