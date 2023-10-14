namespace App1.Application.UseCases.Class1.Commands.Create;

using Domain.Entities;
using Interfaces.CQRS;
using Interfaces.Repositories;
using Mediator;

public class CreateClass1CommandHandler(IClass1Repository class1Repository) : BaseClass1Handler(class1Repository),
                                                                              ICommandHandler<CreateClass1Command, OperationResult<Class1Dto>>
{
	public async ValueTask<OperationResult<Class1Dto>> Handle(CreateClass1Command command, CancellationToken cancellationToken)
	{
		var class1 = new Class1
		{
			Name = command.Name
		};
		var result = await Class1Repository.Add(class1, cancellationToken);
		return new OperationResult<Class1Dto>
		{
			Value = Class1Dto.From(result)
		};
	}
}