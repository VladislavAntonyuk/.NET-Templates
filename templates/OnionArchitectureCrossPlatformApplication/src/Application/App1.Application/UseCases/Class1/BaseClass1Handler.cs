namespace App1.Application.UseCases.Class1;

using AutoMapper;
using Interfaces.Repositories;

public abstract class BaseClass1Handler
{
	protected readonly IClass1Repository Class1Repository;
	protected readonly IMapper Mapper;

	protected BaseClass1Handler(IClass1Repository class1Repository, IMapper mapper)
	{
		Class1Repository = class1Repository;
		Mapper = mapper;
	}
}