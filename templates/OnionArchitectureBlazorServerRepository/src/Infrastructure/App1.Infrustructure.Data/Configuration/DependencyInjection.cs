namespace App1.Infrastructure.Data.Configuration;

using Application.Interfaces.CQRS;
using Application.Interfaces.Repositories;
using Dispatchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Models;

public static class DependencyInjection
{
	public static void AddInfrastructureData(this IServiceCollection services, string? connectionString)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);
		services.AddTransient<ICommandDispatcher, CommandDispatcher>();
		services.AddTransient<IQueryDispatcher, QueryDispatcher>();
		services.AddPooledDbContextFactory<WebAppContext>(opt =>
			                                                  opt.UseSqlServer(connectionString,
			                                                               builder =>
			                                                               {
				                                                               builder.EnableRetryOnFailure(5);
			                                                               }));
		services.AddScoped<IClass1Repository, Class1Repository>();
		services.AddHostedService<MigrationHostedService>();
	}
}