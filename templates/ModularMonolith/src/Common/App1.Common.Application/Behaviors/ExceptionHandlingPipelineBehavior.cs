namespace App1.Common.Application.Behaviors;

using Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

internal sealed class ExceptionHandlingPipelineBehavior<TRequest, TResponse>(
	ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> logger)
	: IPipelineBehavior<TRequest, TResponse> where TRequest : class
{
	public async Task<TResponse> Handle(TRequest request,
		RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
		try
		{
			return await next();
		}
		catch (Exception exception)
		{
			logger.LogError(exception, "Unhandled exception for {RequestName}", typeof(TRequest).Name);

			throw new App1Exception(typeof(TRequest).Name, innerException: exception);
		}
	}
}