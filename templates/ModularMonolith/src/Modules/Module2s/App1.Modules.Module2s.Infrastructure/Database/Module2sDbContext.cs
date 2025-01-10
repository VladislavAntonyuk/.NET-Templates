using App1.Common.Infrastructure.Inbox;
using App1.Common.Infrastructure.Outbox;
using App1.Modules.Module2s.Application.Abstractions.Data;
using App1.Modules.Module2s.Domain.Module2s;
using App1.Modules.Module2s.Infrastructure.Module2s;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App1.Modules.Module2s.Infrastructure.Database;

public sealed class Module2sDbContext(DbContextOptions<Module2sDbContext> options) : DbContext(options), IUnitOfWork
{
	internal DbSet<Module2> Module2S => Set<Module2>();
	internal DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();

	internal DbSet<InboxMessage> InboxMessages => Set<InboxMessage>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema(Schemas.Module2S);

		modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());

		modelBuilder.ApplyConfiguration(new InboxMessageConfiguration());

		modelBuilder.ApplyConfiguration(new Module2Configuration());
	}
}

#if DEBUG
// dotnet ef migrations add "Module2s" -o "Database\Migrations"
public class Module2SDbContextFactory : IDesignTimeDbContextFactory<Module2sDbContext>
{
	public Module2sDbContext CreateDbContext(string[] args)
	{
		return new Module2sDbContext(new DbContextOptionsBuilder<Module2sDbContext>()
		                           .UseSqlServer("Host=localhost;Database=App1;Module2name=sa;Password=password")
		                           .Options);
	}
}
#endif