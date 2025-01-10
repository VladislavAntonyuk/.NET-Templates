using App1.Modules.Module1s.Domain.Module1s;
using App1.Modules.Module1s.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace App1.Modules.Module1s.Infrastructure.Module1s;

internal sealed class Module1Repository(Module1sDbContext context) : IModule1Repository
{
	public async Task<Module1?> GetAsync(Guid id, CancellationToken cancellationToken = default)
	{
		return await context.Module1s.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
	}

	public async Task<List<Module1>> GetAsync(CancellationToken cancellationToken = default)
	{
		return await context.Module1s.ToListAsync(cancellationToken);
	}

	public void Insert(Module1 module1)
	{
		context.Module1s.Add(module1);
	}

	public void Delete(Module1 module1)
	{
		context.Module1s.Remove(module1);
	}

	public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
	{
		await context.Module1s.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
	}
}