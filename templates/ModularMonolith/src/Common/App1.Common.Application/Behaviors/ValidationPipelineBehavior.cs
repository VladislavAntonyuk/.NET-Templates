namespace App1.Common.Application.Behaviors;

using Domain;
using FluentValidation;
using FluentValidation.Results;
using Mediator;
using IBaseCommand = Messaging.IBaseCommand;

internal sealed class ValidationPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
	: IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
{
	public async ValueTask<TResponse> Handle(TRequest message,
		MessageHandlerDelegate<TRequest, TResponse> next,
		CancellationToken cancellationToken)
	{
		var validationFailures = await ValidateAsync(message);

		if (validationFailures.Length == 0)
		{
			return await next(message, cancellationToken);
		}

		if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
		{
			var resultType = typeof(TResponse).GetGenericArguments()[0];

			var failureMethod = typeof(Result<>).MakeGenericType(resultType)
			                                    .GetMethod(nameof(Result<object>.ValidationFailure));

			if (failureMethod is not null)
			{
				return (TResponse)failureMethod.Invoke(null, [CreateValidationError(validationFailures)])!;
			}
		}
		else if (typeof(TResponse) == typeof(Result))
		{
			return (TResponse)(object)Result.Failure(CreateValidationError(validationFailures));
		}

		throw new ValidationException(validationFailures);
	}

	private async Task<ValidationFailure[]> ValidateAsync(TRequest request)
	{
		if (!validators.Any())
		{
			return [];
		}

		var context = new ValidationContext<TRequest>(request);

		ValidationResult[] validationResults = await Task.WhenAll(
			validators.Select(validator => validator.ValidateAsync(context)));

		ValidationFailure[] validationFailures = validationResults.Where(validationResult => !validationResult.IsValid)
		                                                          .SelectMany(
			                                                          validationResult => validationResult.Errors)
		                                                          .ToArray();

		return validationFailures;
	}

	private static ValidationError CreateValidationError(ValidationFailure[] validationFailures)
	{
		return new ValidationError(validationFailures.Select(f => Error.Problem(f.ErrorCode, f.ErrorMessage))
		                                             .ToArray());
	}
}