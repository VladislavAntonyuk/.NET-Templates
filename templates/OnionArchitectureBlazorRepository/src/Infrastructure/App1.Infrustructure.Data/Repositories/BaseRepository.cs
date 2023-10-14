namespace App1.Infrastructure.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Models;

public abstract class BaseRepository
{
	protected Task SaveChangesAsync(DbContext context, CancellationToken cancellationToken)
	{
		foreach (var entry in context.ChangeTracker.Entries<BaseModel>().Where(x => x.State is EntityState.Added or EntityState.Modified).Select(x => x.Entity))
		{
			entry.ModifiedOn = DateTime.UtcNow;
			if (entry.CreatedOn <= DateTime.MinValue)
			{
				entry.CreatedOn = DateTime.UtcNow;
			}
		}

		return context.SaveChangesAsync(cancellationToken);
	}
}