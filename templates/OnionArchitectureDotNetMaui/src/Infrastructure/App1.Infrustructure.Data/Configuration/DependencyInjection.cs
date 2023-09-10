namespace App1.Infrastructure.Data.Configuration;

using System.Reflection;
using Application.Interfaces.CQRS;
using Dispatchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Models;

public static class DependencyInjection
{
	public static void AddInfrastructureData(this IServiceCollection services, string connectionString)
	{
		services.AddTransient<ICommandDispatcher, CommandDispatcher>();
		services.AddTransient<IQueryDispatcher, QueryDispatcher>();
		services.AddPooledDbContextFactory<ApplicationContext>(opt => opt.UseSqlite(connectionString, builder =>
		{
			builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
		}));
	}
}