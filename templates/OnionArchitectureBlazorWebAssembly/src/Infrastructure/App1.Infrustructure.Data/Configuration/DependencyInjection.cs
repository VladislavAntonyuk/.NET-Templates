namespace App1.Infrastructure.Data.Configuration;

using Application.Interfaces;
using Application.Interfaces.CQRS;
using Dispatchers;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

public static class DependencyInjection
{
	public static void AddInfrastructureData(this IServiceCollection services)
	{
		services.AddTransient<ICommandDispatcher, CommandDispatcher>();
		services.AddTransient<IQueryDispatcher, QueryDispatcher>();
		services.AddTransient<IClass1Repository, Class1Repository>();
	}
}