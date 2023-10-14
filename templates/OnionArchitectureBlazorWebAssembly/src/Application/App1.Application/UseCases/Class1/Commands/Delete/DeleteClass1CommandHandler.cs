namespace App1.Application.UseCases.Class1.Commands.Delete;

using Domain.Entities;
using Interfaces;
using Interfaces.CQRS;
using Mediator;

public class DeleteClass1CommandHandler(IClass1Repository class1Repository) : ICommandHandler<DeleteClass1Command, OperationResult>
{
	public async ValueTask<OperationResult> Handle(DeleteClass1Command command, CancellationToken cancellationToken)
	{
		await class1Repository.Delete(new Class1
		{
			Id = command.Class1Id
		}, cancellationToken);
		return new OperationResult();
	}
}