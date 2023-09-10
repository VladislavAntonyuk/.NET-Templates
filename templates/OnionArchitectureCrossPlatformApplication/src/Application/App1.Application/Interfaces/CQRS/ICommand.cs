namespace App1.Application.Interfaces.CQRS;

using Mediator;

public interface ICommand<out TResult> : IRequest<IOperationResult<TResult>>
{
}