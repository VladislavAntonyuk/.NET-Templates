namespace App1.Application.UseCases.Class1.Commands.Delete;

using Interfaces.CQRS;
using Interfaces.Repositories;
using Mediator;

public class DeleteClass1CommandHandler(IClass1Repository class1Repository) : BaseClass1Handler(class1Repository),
                                                                              ICommandHandler<DeleteClass1Command, OperationResult>
{
	public async ValueTask<OperationResult> Handle(DeleteClass1Command command, CancellationToken cancellationToken)
	{
		var class1 = await Class1Repository.GetById(command.Class1Id, cancellationToken);
		if (class1 is not null)
		{
			await Class1Repository.Delete(class1, cancellationToken);
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