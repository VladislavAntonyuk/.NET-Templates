namespace App1.Infrastructure.Data.Repositories.Models;

using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
	}

	public virtual DbSet<Class1> Class1 => Set<Class1>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Class1>(entity =>
		{
			entity.HasIndex(e => e.Name).IsUnique();
		});
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