namespace App1.Infrastructure.Data.Dispatchers;

using Application.Interfaces.CQRS;
using FluentValidation;
using Mediator;

public class CommandDispatcher(ISender sender) : ICommandDispatcher
{
	public async ValueTask<TResult> SendAsync<TResult>(ICommand<TResult> command,
		CancellationToken cancellationToken = default) where TResult : OperationResult, new()
	{
		try
		{
			return await sender.Send(command, cancellationToken);
		}
		catch (ValidationException ex)
		{
			var result = new TResult();
			foreach (var error in ex.Errors)
			{
				result.Errors.Add(new Error { Description = error.ErrorMessage });
			}

			return result;
		}
		catch (Exception e)
		{
			var result = new TResult()
			{
				Errors =
				{
					new()
					{
						Description = e.Message
					}
				}
			};
			return result;
		}
	}
}