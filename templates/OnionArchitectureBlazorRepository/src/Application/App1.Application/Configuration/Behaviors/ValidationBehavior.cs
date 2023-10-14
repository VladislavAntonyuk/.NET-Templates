namespace App1.Application.Configuration.Behaviors;

using FluentValidation;
using Interfaces.CQRS;
using Mediator;

public class ValidationBehavior<TRequest, TResponse>
	(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse> where TResponse : OperationResult, new()
{
	public async ValueTask<TResponse> Handle(TRequest request,
		MessageHandlerDelegate<TRequest, TResponse> next,
		CancellationToken cancellationToken)
	{
		if (!validators.Any())
		{
			return await next(request, cancellationToken);
		}

		var context = new ValidationContext<TRequest>(request);

		var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
		var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
		if (failures.Count != 0)
		{
			var response = new TResponse();
			foreach (var failure in failures)
			{
				response.Errors.Add(new Error
				{
					Description = failure.ErrorMessage
				});
			}

			return response;
		}

		return await next(request, cancellationToken);
	}
}