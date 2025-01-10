namespace App1.Modules.Module1s.Domain.Module1s;

public interface IModule1Repository
{
	Task<Module1?> GetAsync(Guid id, CancellationToken cancellationToken = default);
	Task<List<Module1>> GetAsync(CancellationToken cancellationToken = default);

	void Insert(Module1 module1);
	void Delete(Module1 module1);
}