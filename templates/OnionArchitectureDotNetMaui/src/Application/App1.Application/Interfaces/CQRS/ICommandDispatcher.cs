namespace App1.Application.Interfaces.CQRS;

public interface ICommandDispatcher
{
	ValueTask<IOperationResult<TResult>> SendAsync<TResult, TCommand>(TCommand command, CancellationToken cancellationToken)
		where TCommand : ICommand<TResult>;
}