namespace App1.Infrastructure.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Models;

public abstract class BaseRepository
{
	protected async Task SaveChangesAsync(DbContext context, CancellationToken cancellationToken)
	{
		foreach (var entry in context.ChangeTracker.Entries<BaseModel>())
		{
			switch (entry.State)
			{
				case EntityState.Added:
					entry.Entity.CreatedOn = DateTime.UtcNow;
					break;

				case EntityState.Modified:
					entry.Entity.ModifiedOn = DateTime.UtcNow;
					break;
			}
		}

		await context.SaveChangesAsync(cancellationToken);
	}
}