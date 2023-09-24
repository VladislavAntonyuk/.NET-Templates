namespace App1.Application.UseCases.Class1.Commands.Delete;

using Interfaces.CQRS;
using Interfaces.Repositories;

public class DeleteClass1CommandHandler : BaseClass1Handler, ICommandHandler<bool, DeleteClass1Command>
{
	public DeleteClass1CommandHandler(IClass1Repository class1Repository) : base(class1Repository)
	{
	}

	public async ValueTask<IOperationResult<bool>> Handle(DeleteClass1Command command, CancellationToken cancellationToken)
	{
		var class1 = await Class1Repository.GetById(command.Class1Id, cancellationToken);
		if (class1 is not null)
		{
			await Class1Repository.Delete(class1, cancellationToken);
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