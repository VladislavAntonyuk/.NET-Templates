namespace App1.Infrastructure.Client.Data.Configuration;

using System.Reflection;
using Application.Configuration.Database;
using Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
	public static void AddInfrastructureData(this IServiceCollection services, string connectionString)
	{
		services.AddCommonInfrastructureData();
		services.AddPooledDbContextFactory<ApplicationContext>(opt => opt.UseSqlite(connectionString, builder =>
		{
			builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
		}));
	}
}