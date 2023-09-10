namespace App1.Application.UseCases.Class1.Commands.Delete;

using Domain.Entities;
using Interfaces;
using Interfaces.CQRS;

public class DeleteClass1CommandHandler : ICommandHandler<bool, DeleteClass1Command>
{
	private readonly IClass1Repository class1Repository;

	public DeleteClass1CommandHandler(IClass1Repository class1Repository)
	{
		this.class1Repository = class1Repository;
	}

	public async ValueTask<IOperationResult<bool>> Handle(DeleteClass1Command command, CancellationToken cancellationToken)
	{
		await class1Repository.Delete(new Class1()
		{
			Id = command.Class1Id
		}, cancellationToken);
		return new OperationResult<bool>()
		{
			Value = true
		};
	}
}