namespace App1.Modules.Module2s.Domain.Module2s;

public interface IModule2Repository
{
	Task<Module2?> GetAsync(Guid id, CancellationToken cancellationToken = default);
	Task<List<Module2>> GetAsync(CancellationToken cancellationToken = default);

	void Insert(Module2 module2);
	void Delete(Module2 module2);
}