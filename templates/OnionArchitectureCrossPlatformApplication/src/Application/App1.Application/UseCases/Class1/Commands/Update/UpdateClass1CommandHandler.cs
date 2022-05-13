namespace App1.Application.UseCases.Class1.Commands.Update;

using AutoMapper;
using Domain.Entities;
using Interfaces.CQRS;
using Interfaces.Repositories;

public class UpdateClass1CommandHandler : BaseClass1Handler, ICommandHandler<Class1Dto, UpdateClass1Command>
{
	public UpdateClass1CommandHandler(IClass1Repository class1Repository, IMapper mapper) : base(class1Repository, mapper)
	{
	}

	public async Task<IOperationResult<Class1Dto>> Handle(UpdateClass1Command command, CancellationToken cancellationToken)
	{
		var class1 = await Class1Repository.GetById(command.Id, cancellationToken);
		if (class1 is not null)
		{
			var classToUpdate = Mapper.Map<Class1>(command);
			var updatedClass = await Class1Repository.Update(classToUpdate, cancellationToken);
			return new OperationResult<Class1Dto>
			{
				Value = Mapper.Map<Class1Dto>(updatedClass)
			};
		}

		var result = new OperationResult<Class1Dto>();
		result.Errors.Add("Class1 not found");
		return result;
	}
}