namespace App1.Infrastructure.Data.Configuration;

using System.Reflection;
using Application.Configuration.Database;
using Application.Interfaces.CQRS;
using Dispatchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
	public static void AddInfrastructureData(this IServiceCollection services, string? connectionString)
	{
		ArgumentException.ThrowIfNullOrEmpty(connectionString);
		services.AddTransient<ICommandDispatcher, CommandDispatcher>();
		services.AddTransient<IQueryDispatcher, QueryDispatcher>();
		services.AddPooledDbContextFactory<ApplicationContext>(opt =>
																   opt.UseSqlServer(connectionString,
																	 builder =>
																	 {
																		 builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
																		 builder.EnableRetryOnFailure(5);
																	 }));
		services.AddHostedService<MigrationHostedService>();
	}
}