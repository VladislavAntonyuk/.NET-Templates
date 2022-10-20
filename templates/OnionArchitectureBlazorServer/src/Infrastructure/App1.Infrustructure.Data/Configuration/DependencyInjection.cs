namespace App1.Infrastructure.Data.Configuration;

using System.Reflection;
using Application.Interfaces.CQRS;
using Application.Interfaces.Repositories;
using Dispatchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Models;

public static class DependencyInjection
{
	public static void AddInfrastructureData(this IServiceCollection services, string connectionString)
	{
		services.AddTransient<ICommandDispatcher, CommandDispatcher>();
		services.AddTransient<IQueryDispatcher, QueryDispatcher>();
		services.AddPooledDbContextFactory<WebAppContext>(opt =>
			                                                  opt.UseMySql(connectionString,
			                                                               ServerVersion.AutoDetect(connectionString),
			                                                               builder =>
			                                                               {
				                                                               builder.EnableRetryOnFailure(5);
			                                                               }));

		services.AddAutoMapper(typeof(DependencyInjection));

		services.AddScoped<IClass1Repository, Class1Repository>();
		services.AddHostedService<MigrationHostedService>();
	}
}