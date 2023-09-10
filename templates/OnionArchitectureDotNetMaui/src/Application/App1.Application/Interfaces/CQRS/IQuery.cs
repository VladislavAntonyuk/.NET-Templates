namespace App1.Application.Interfaces.CQRS;

using Mediator;

public interface IQuery<out TResult> : IRequest<IOperationResult<TResult>>
{
}