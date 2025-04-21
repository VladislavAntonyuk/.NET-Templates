using App1.ApiService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace App1.ApiService.Infrastructure.Extensions;

public static class MigrationExtensions
{
	public static async Task ApplyMigrations(this IApplicationBuilder app)
	{
		using var scope = app.ApplicationServices.CreateScope();

		await ApplyMigration<Module1sDbContext>(scope);
	}

	private static async Task ApplyMigration<TDbContext>(IServiceScope scope) where TDbContext : DbContext
	{
		await using var context = scope.ServiceProvider.GetRequiredService<TDbContext>();
		await context.Database.MigrateAsync();
	}
}