namespace App1.Application.Interfaces.Repositories;

using Domain.Entities;

public interface IClass1Repository
{
	Task<Class1> Add(Class1 class1, CancellationToken cancellationToken);
	void Update(Class1 class1);
	void Delete(Class1 class1);
	Task<Class1?> GetById(int id, CancellationToken cancellationToken);
	Task<bool> IsExist(string parameter, CancellationToken cancellationToken);
	IEnumerable<Class1> GetAll();
	Task<IPaginatedList<Class1>> GetPagedAsync(string? parameter, int requestOffset, int requestLimit, CancellationToken cancellationToken);
}