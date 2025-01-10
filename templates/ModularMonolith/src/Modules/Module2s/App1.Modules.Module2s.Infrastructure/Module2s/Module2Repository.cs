using App1.Modules.Module2s.Domain.Module2s;
using App1.Modules.Module2s.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace App1.Modules.Module2s.Infrastructure.Module2s;

internal sealed class Module2Repository(Module2sDbContext context) : IModule2Repository
{
	public async Task<Module2?> GetAsync(Guid id, CancellationToken cancellationToken = default)
	{
		return await context.Module2S.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
	}

	public async Task<List<Module2>> GetAsync(CancellationToken cancellationToken = default)
	{
		return await context.Module2S.ToListAsync(cancellationToken);
	}

	public void Insert(Module2 module2)
	{
		context.Module2S.Add(module2);
	}

	public void Delete(Module2 module2)
	{
		context.Module2S.Remove(module2);
	}

	public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
	{
		await context.Module2S.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
	}
}