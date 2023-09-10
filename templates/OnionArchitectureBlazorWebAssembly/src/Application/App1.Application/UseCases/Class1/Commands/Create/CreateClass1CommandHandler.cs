namespace App1.Application.UseCases.Class1.Commands.Create;

using Domain.Entities;
using Interfaces;
using Interfaces.CQRS;

public class CreateClass1CommandHandler : ICommandHandler<Class1Dto, CreateClass1Command>
{
	private readonly IClass1Repository class1Repository;

	public CreateClass1CommandHandler(IClass1Repository class1Repository)
	{
		this.class1Repository = class1Repository;
	}

	public async ValueTask<IOperationResult<Class1Dto>> Handle(CreateClass1Command command, CancellationToken cancellationToken)
	{
		var class1 = new Class1
		{
			Name = command.Name
		};
		var result = await class1Repository.Add(class1, cancellationToken);
		if (result is null)
		{
			var operationResult = new OperationResult<Class1Dto>();
			operationResult.Errors.Add("Class1 not created");
			return operationResult;
		}

		return new OperationResult<Class1Dto>
		{
			Value = Class1Dto.From(result)
		};
	}
}