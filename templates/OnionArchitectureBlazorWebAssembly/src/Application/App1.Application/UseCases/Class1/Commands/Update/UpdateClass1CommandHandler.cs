namespace App1.Application.UseCases.Class1.Commands.Update;

using Domain.Entities;
using Interfaces;
using Interfaces.CQRS;
using Mediator;

public class UpdateClass1CommandHandler(IClass1Repository class1Repository) : ICommandHandler<UpdateClass1Command, OperationResult>
{
	public async ValueTask<OperationResult> Handle(UpdateClass1Command command, CancellationToken cancellationToken)
	{
		await class1Repository.Update(new Class1
		{
			Id = command.Id,
			Name = command.Name
		}, cancellationToken);
		return new OperationResult();
	}
}