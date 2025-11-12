namespace App1.Common.Application.Behaviors;

using System.Diagnostics;
using Domain;
using Mediator;
using Microsoft.Extensions.Logging;

internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
	ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
	: IPipelineBehavior<TRequest, TResponse> where TRequest : class, IMessage where TResponse : Result
{
	public async ValueTask<TResponse> Handle(TRequest message,
		MessageHandlerDelegate<TRequest, TResponse> next,
		CancellationToken cancellationToken)
	{
		var moduleName = GetModuleName(typeof(TRequest).FullName!);
		var requestName = typeof(TRequest).Name;

		Activity.Current?.SetTag("request.module", moduleName);
		Activity.Current?.SetTag("request.name", requestName);

		using (logger.BeginScope("Module {ModuleName}", moduleName))
		{
			logger.LogInformation("Processing request {RequestName}", requestName);

			var result = await next(message, cancellationToken);

			if (result.IsSuccess)
			{
				logger.LogInformation("Completed request {RequestName}", requestName);
			}
			else
			{
				using (logger.BeginScope("Error {Error}", result.Error))
				{
					logger.LogError("Completed request {RequestName} with error", requestName);
				}
			}

			return result;
		}
	}

	private static string GetModuleName(string requestName)
	{
		return requestName.Split('.')[2];
	}
}