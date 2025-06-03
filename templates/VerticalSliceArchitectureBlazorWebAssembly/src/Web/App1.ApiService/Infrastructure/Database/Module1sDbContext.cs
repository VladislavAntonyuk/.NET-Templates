using App1.ApiService.Application.Module1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App1.ApiService.Infrastructure.Database;

public sealed class Module1sDbContext(DbContextOptions<Module1sDbContext> options) : DbContext(options)
{
	internal DbSet<Module1> Module1s => Set<Module1>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema(Schemas.Module1s);

		modelBuilder.ApplyConfiguration(new Module1Configuration());
	}
}

#if DEBUG
// dotnet ef migrations add "Module1s" -o "Infrastructure\Database\Migrations"
public class Module1SDbContextFactory : IDesignTimeDbContextFactory<Module1sDbContext>
{
	public Module1sDbContext CreateDbContext(string[] args)
	{
		return new Module1sDbContext(new DbContextOptionsBuilder<Module1sDbContext>()
		                          .UseSqlServer("Host=localhost;Database=App1;Module1name=sa;Password=password")
		                          .Options);
	}
}
#endif