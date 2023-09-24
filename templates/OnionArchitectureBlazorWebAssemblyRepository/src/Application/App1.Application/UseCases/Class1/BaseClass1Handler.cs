namespace App1.Application.UseCases.Class1;

using Interfaces.Repositories;

public abstract class BaseClass1Handler
{
	protected readonly IClass1Repository Class1Repository;

	protected BaseClass1Handler(IClass1Repository class1Repository)
	{
		Class1Repository = class1Repository;
	}
}