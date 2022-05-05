namespace App1.Application.UseCases.Class1.Commands.Update;

using AutoMapper;
using Domain.Entities;
using Interfaces.CQRS;
using Interfaces.Repositories;

public class UpdateClass1CommandHandler : BaseClass1Handler, ICommandHandler<Class1Dto, UpdateClass1Command>
{
	public UpdateClass1CommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<IOperationResult<Class1Dto>> Handle(UpdateClass1Command request, CancellationToken cancellationToken)
	{
		var banner = Mapper.Map<Class1>(request);
		UnitOfWork.Class1Repository.Update(banner);
		await UnitOfWork.Save(cancellationToken);
		return new OperationResult<Class1Dto>
		{
			Value = Mapper.Map<Class1Dto>(banner)
		};
	}
}
