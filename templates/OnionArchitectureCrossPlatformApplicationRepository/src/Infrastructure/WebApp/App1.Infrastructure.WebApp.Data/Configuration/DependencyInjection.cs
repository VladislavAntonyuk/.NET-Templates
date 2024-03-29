﻿namespace App1.Infrastructure.WebApp.Data.Configuration;

using System.Reflection;
using Application.Interfaces.Repositories;
using Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Models;

public static class DependencyInjection
{
	public static void AddInfrastructureData(this IServiceCollection services, string? connectionString)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);
		services.AddCommonInfrastructureData();
		services.AddPooledDbContextFactory<WebAppContext>(opt =>
															  opt.UseSqlServer(connectionString,
																		   builder =>
																		   {
																			   builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
																			   builder.EnableRetryOnFailure(5);
																		   }));

		services.AddScoped<IClass1Repository, Class1Repository>();
		services.AddHostedService<MigrationHostedService>();
	}
}