namespace App1.Application.UseCases.Class1;

using AutoMapper;
using Interfaces.Repositories;

public abstract class BaseClass1Handler
{
	protected readonly IUnitOfWork UnitOfWork;
	protected readonly IMapper Mapper;

	protected BaseClass1Handler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		this.UnitOfWork = unitOfWork;
		this.Mapper = mapper;
	}
}