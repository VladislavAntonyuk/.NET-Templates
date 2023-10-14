namespace App1.Application.UseCases.Class1;

using Interfaces.Repositories;

public abstract class BaseClass1Handler(IClass1Repository class1Repository)
{
	protected readonly IClass1Repository Class1Repository = class1Repository;
}