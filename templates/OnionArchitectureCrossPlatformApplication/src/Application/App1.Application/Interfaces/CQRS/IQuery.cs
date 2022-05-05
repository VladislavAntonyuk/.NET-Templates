namespace App1.Application.Interfaces.CQRS;

using MediatR;

public interface IQuery<out TResult> : IRequest<IOperationResult<TResult>>
{
}