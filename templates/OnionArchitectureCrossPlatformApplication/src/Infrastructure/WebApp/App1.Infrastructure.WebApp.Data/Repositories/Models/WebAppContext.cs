namespace App1.Infrastructure.WebApp.Data.Repositories.Models;

using Microsoft.EntityFrameworkCore;

public partial class WebAppContext : DbContext
{
	public WebAppContext(DbContextOptions<WebAppContext> options)
		: base(options)
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