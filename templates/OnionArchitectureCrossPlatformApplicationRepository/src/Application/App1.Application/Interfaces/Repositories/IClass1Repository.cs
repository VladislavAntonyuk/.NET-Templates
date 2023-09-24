namespace App1.Application.Interfaces.Repositories;

using Domain.Entities;

public interface IClass1Repository
{
	Task<Class1> Add(Class1 class1, CancellationToken cancellationToken);
	Task<Class1> Update(Class1 class1, CancellationToken cancellationToken);
	Task Delete(Class1 class1, CancellationToken cancellationToken);
	Task<Class1?> GetById(int id, CancellationToken cancellationToken);
	Task<bool> IsExist(string parameter, CancellationToken cancellationToken);
	Task<IList<Class1>> GetAll(CancellationToken cancellationToken);
}