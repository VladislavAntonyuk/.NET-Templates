namespace App1.Application.UseCases.Class1.Commands.Create;

using Domain.Entities;
using Interfaces.CQRS;
using Interfaces.Repositories;

public class CreateClass1CommandHandler : BaseClass1Handler, ICommandHandler<Class1Dto, CreateClass1Command>
{
	public CreateClass1CommandHandler(IClass1Repository class1Repository) : base(class1Repository)
	{
	}

	public async ValueTask<IOperationResult<Class1Dto>> Handle(CreateClass1Command command, CancellationToken cancellationToken)
	{
		var class1 = new Class1()
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