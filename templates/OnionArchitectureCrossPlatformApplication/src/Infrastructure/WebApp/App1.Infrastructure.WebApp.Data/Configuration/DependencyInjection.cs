namespace App1.Infrastructure.WebApp.Data.Configuration;

using System.Reflection;
using Infrastructure.Data.Configuration;
using Infrastructure.Data.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
	public static void AddInfrastructureData(this IServiceCollection services, string? connectionString)
	{
		ArgumentException.ThrowIfNullOrEmpty(connectionString);
		services.AddCommonInfrastructureData();
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