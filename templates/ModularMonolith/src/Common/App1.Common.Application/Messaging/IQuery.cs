using Mediator;

namespace App1.Common.Application.Messaging;

using Domain;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;