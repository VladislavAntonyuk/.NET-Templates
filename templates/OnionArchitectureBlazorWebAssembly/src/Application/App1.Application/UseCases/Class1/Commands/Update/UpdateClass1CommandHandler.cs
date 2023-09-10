namespace App1.Application.UseCases.Class1.Commands.Update;

using Domain.Entities;
using Interfaces;
using Interfaces.CQRS;

public class UpdateClass1CommandHandler : ICommandHandler<bool, UpdateClass1Command>
{
	private readonly IClass1Repository class1Repository;

	public UpdateClass1CommandHandler(IClass1Repository class1Repository)
	{
		this.class1Repository = class1Repository;
	}

	public async ValueTask<IOperationResult<bool>> Handle(UpdateClass1Command command, CancellationToken cancellationToken)
	{
		var result = await class1Repository.Update(new Class1()
		{
			Id = command.Id,
			Name = command.Name
		}, cancellationToken);
		return new OperationResult<bool>()
		{
			Value = result
		};
	}
}