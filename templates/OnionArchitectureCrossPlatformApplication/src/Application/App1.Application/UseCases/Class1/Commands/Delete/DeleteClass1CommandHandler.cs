namespace App1.Application.UseCases.Class1.Commands.Delete;

using AutoMapper;
using Domain.Entities;
using Interfaces.CQRS;
using Interfaces.Repositories;

public class DeleteClass1CommandHandler : BaseClass1Handler, ICommandHandler<bool, DeleteClass1Command>
{
	public DeleteClass1CommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<IOperationResult<bool>> Handle(DeleteClass1Command command, CancellationToken cancellationToken = default)
	{
		var class1 = Mapper.Map<Class1>(command);
		UnitOfWork.Class1Repository.Delete(class1);
		await UnitOfWork.Save(cancellationToken);
		return new OperationResult<bool>
		{
			Value = true
		};
	}
}
