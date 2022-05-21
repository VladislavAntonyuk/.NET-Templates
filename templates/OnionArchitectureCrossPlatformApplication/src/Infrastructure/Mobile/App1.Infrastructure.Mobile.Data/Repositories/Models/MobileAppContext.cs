namespace App1.Infrastructure.Mobile.Data.Repositories.Models;

using Microsoft.EntityFrameworkCore;

public partial class MobileAppContext : DbContext
{
	public MobileAppContext(DbContextOptions<MobileAppContext> options) : base(options)
	{
	}

	public virtual DbSet<Class1> Class1 => Set<Class1>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Class1>(entity =>
		{
			entity.HasIndex(e => e.Name).IsUnique();
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}