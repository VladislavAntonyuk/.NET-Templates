namespace App1.Application.Interfaces;

using Domain.Entities;

public interface IClass1Repository
{
	Task<Class1?> Add(Class1 class1, CancellationToken cancellationToken);
	Task<bool> Update(Class1 class1, CancellationToken cancellationToken);
	Task Delete(Class1 class1, CancellationToken cancellationToken);
	Task<Class1?> GetById(int id, CancellationToken cancellationToken);
	Task<bool> IsExist(string parameter, CancellationToken cancellationToken);
	Task<IEnumerable<Class1>> GetAll(CancellationToken cancellationToken);
}