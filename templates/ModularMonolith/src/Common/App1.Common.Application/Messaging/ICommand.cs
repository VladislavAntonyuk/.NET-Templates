using Mediator;

namespace App1.Common.Application.Messaging;

using Domain;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand : IMessage;