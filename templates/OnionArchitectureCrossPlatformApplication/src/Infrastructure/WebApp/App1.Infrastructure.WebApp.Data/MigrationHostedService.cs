namespace App1.Infrastructure.WebApp.Data;

using Application.Configuration.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class MigrationHostedService(IServiceProvider serviceProvider) : IHostedService
{
	public async Task StartAsync(CancellationToken cancellationToken)
	{
		await using var scope = serviceProvider.CreateAsyncScope();
		var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationContext>>();
		await using var context = await factory.CreateDbContextAsync(cancellationToken);
		await context.Database.MigrateAsync(cancellationToken);
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}