namespace App1.Application.UseCases.Class1.Commands.Update;

using Domain.Entities;
using Interfaces.CQRS;
using Interfaces.Repositories;

public class UpdateClass1CommandHandler : BaseClass1Handler, ICommandHandler<bool, UpdateClass1Command>
{
	public UpdateClass1CommandHandler(IClass1Repository class1Repository) : base(class1Repository)
	{
	}

	public async ValueTask<IOperationResult<bool>> Handle(UpdateClass1Command command, CancellationToken cancellationToken)
	{
		var class1 = await Class1Repository.GetById(command.Id, cancellationToken);
		if (class1 is not null)
		{
			var class1ToUpdate = new Class1
			{
				Id = class1.Id,
				CreatedOn = class1.CreatedOn,
				Name = command.Title
			};
			var updatedClass = await Class1Repository.Update(class1ToUpdate, cancellationToken);
			return new OperationResult<bool>
			{
				Value = true
			};
		}

		var result = new OperationResult<bool>();
		result.Errors.Add("Class1 not found");
		return result;
	}
}