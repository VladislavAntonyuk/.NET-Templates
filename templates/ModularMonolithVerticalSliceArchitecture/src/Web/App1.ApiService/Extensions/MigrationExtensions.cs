using App1.Modules.Module1s.Infrastructure.Database;
using App1.Modules.Module2s.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace App1.ApiService.Extensions;

public static class MigrationExtensions
{
	public static async Task ApplyMigrations(this IApplicationBuilder app)
	{
		using var scope = app.ApplicationServices.CreateScope();

		await ApplyMigration<Module1sDbContext>(scope);
		await ApplyMigration<Module2sDbContext>(scope);
	}

	private static async Task ApplyMigration<TDbContext>(IServiceScope scope) where TDbContext : DbContext
	{
		await using var context = scope.ServiceProvider.GetRequiredService<TDbContext>();
		await context.Database.MigrateAsync();
	}
}