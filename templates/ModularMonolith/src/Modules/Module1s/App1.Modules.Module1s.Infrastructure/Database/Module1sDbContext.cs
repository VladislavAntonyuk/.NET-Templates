using App1.Common.Infrastructure.Outbox;
using App1.Modules.Module1s.Application.Abstractions.Data;
using App1.Modules.Module1s.Domain.Module1s;
using App1.Modules.Module1s.Infrastructure.Module1s;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App1.Modules.Module1s.Infrastructure.Database;

public sealed class Module1sDbContext(DbContextOptions<Module1sDbContext> options) : DbContext(options), IUnitOfWork
{
	internal DbSet<Module1> Module1s => Set<Module1>();

	internal DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema(Schemas.Module1s);

		modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());

		modelBuilder.ApplyConfiguration(new Module1Configuration());
	}
}

#if DEBUG
// dotnet ef migrations add "Module1s" -o "Database\Migrations"
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