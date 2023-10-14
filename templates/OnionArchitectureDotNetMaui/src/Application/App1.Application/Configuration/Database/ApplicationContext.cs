namespace App1.Application.Configuration.Database;

using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
	public DbSet<Class1> Class1 => Set<Class1>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new Class1Configuration());
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
	{
		foreach (var entry in ChangeTracker.Entries<BaseEntity>().Where(x => x.State is EntityState.Added or EntityState.Modified).Select(x => x.Entity))
		{
			entry.ModifiedOn = DateTime.UtcNow;
			if (entry.CreatedOn <= DateTime.MinValue)
			{
				entry.CreatedOn = DateTime.UtcNow;
			}
		}

		return base.SaveChangesAsync(cancellationToken);
	}
}