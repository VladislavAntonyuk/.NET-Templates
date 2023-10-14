namespace App1.Application.Interfaces.CQRS;

using Mediator;

public interface ICommandDispatcher
{
	ValueTask<TResult> SendAsync<TResult>(
		ICommand<TResult> command,
		CancellationToken cancellationToken = default);
}