namespace App1.Application.UseCases.Class1.Commands.Update;

using Domain.Entities;
using Interfaces.CQRS;
using Interfaces.Repositories;
using Mediator;

public class UpdateClass1CommandHandler(IClass1Repository class1Repository) : BaseClass1Handler(class1Repository),
                                                                              ICommandHandler<UpdateClass1Command, OperationResult>
{
	public async ValueTask<OperationResult> Handle(UpdateClass1Command command, CancellationToken cancellationToken)
	{
		var class1 = await Class1Repository.GetById(command.Id, cancellationToken);
		if (class1 is not null)
		{
			var class1ToUpdate = new Class1
			{
				Id = class1.Id,
				CreatedOn = class1.CreatedOn,
				Name = command.Name
			};
			await Class1Repository.Update(class1ToUpdate, cancellationToken);
			return new OperationResult();
		}

		var result = new OperationResult();
		result.Errors.Add(new Error()
		{
			Description = "Class1 not found"
		});
		return result;
	}
}