namespace App1.Application.Interfaces.CQRS;

using Mediator;

public interface ICommandHandler<TResult, in TCommand> : IRequestHandler<TCommand, IOperationResult<TResult>>
	where TCommand : ICommand<TResult>
{
}