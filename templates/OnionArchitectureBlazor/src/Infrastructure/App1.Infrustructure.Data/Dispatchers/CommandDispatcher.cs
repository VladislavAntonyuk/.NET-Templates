namespace App1.Infrastructure.Data.Dispatchers;

using Application.Interfaces.CQRS;
using Mediator;

public class CommandDispatcher(ISender sender) : ICommandDispatcher
{
	public ValueTask<TResult> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
	{
		return sender.Send(command, cancellationToken);
	}
}