namespace App1.Application.UseCases.Class1.Commands.Create;

using Domain.Entities;
using Interfaces;
using Interfaces.CQRS;
using Mediator;
using Models;

public class CreateClass1CommandHandler(IClass1Repository class1Repository) : ICommandHandler<CreateClass1Command, OperationResult<Class1Dto>>
{
	public async ValueTask<OperationResult<Class1Dto>> Handle(CreateClass1Command command, CancellationToken cancellationToken)
	{
		var class1 = new Class1
		{
			Name = command.Name
		};
		var result = await class1Repository.Add(class1, cancellationToken);
		if (result is null)
		{
			var operationResult = new OperationResult<Class1Dto>();
			operationResult.Errors.Add(new Error()
			{
				Description = "Class1 not created"
			});
			return operationResult;
		}

		return new OperationResult<Class1Dto>
		{
			Value = Class1Dto.From(result)
		};
	}
}