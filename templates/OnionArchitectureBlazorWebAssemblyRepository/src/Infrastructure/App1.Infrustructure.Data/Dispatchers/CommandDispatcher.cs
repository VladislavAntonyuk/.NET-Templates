namespace App1.Infrastructure.Data.Dispatchers;

using Application.Interfaces.CQRS;
using Mediator;

public class CommandDispatcher : ICommandDispatcher
{
	private readonly ISender sender;

	public CommandDispatcher(ISender sender)
	{
		this.sender = sender;
	}

	public ValueTask<IOperationResult<TResult>> SendAsync<TResult, TCommand>(TCommand command, CancellationToken cancellationToken)
		where TCommand : Application.Interfaces.CQRS.ICommand<TResult>
    {
		return sender.Send(command, cancellationToken);
	}
}