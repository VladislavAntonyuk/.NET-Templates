namespace App1.Application.UseCases.Class1.Commands.Create;

using AutoMapper;
using Domain.Entities;
using Interfaces.CQRS;
using Interfaces.Repositories;

public class CreateClass1CommandHandler : BaseClass1Handler, ICommandHandler<Class1Dto, CreateClass1Command>
{
	public CreateClass1CommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<IOperationResult<Class1Dto>> Handle(CreateClass1Command request, CancellationToken cancellationToken)
	{
		var banner = Mapper.Map<Class1>(request);
		var result = await UnitOfWork.Class1Repository.Add(banner, cancellationToken);
		await UnitOfWork.Save(cancellationToken);
		return new OperationResult<Class1Dto>
		{
			Value = Mapper.Map<Class1Dto>(result)
		};
	}
}
