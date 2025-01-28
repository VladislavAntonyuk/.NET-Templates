namespace App1.Common.Infrastructure;

using Application.EventBus;
using Authentication;
using Authorization;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Outbox;
using Quartz;

public static class InfrastructureConfiguration
{
	public static IServiceCollection AddAuthZ(this IServiceCollection services)
	{
		services.AddOpenIdAuthorizationInternal();
		return services;
	}

	public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder,
		Action<IRegistrationConfigurator>[] moduleConfigureConsumers)
	{
		builder.Services.AddAuthenticationInternal(builder.Configuration);

		builder.Services.AddJwtAuthorizationInternal();

		builder.Services.TryAddSingleton<IEventBus, EventBus.EventBus>();

		builder.Services.TryAddSingleton<InsertOutboxMessagesInterceptor>();

		builder.Services.AddQuartz(configurator =>
		{
			var scheduler = Guid.NewGuid();
			configurator.SchedulerId = $"default-id-{scheduler}";
			configurator.SchedulerName = $"default-name-{scheduler}";
		});

		builder.Services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

#pragma warning disable EXTEXP0018
		builder.Services.AddHybridCache();
#pragma warning restore EXTEXP0018
		if (!builder.Environment.IsDevelopment())
		{
			builder.AddRedisDistributedCache("cache");
		}

		builder.Services.AddMassTransit(configure =>
		{
			foreach (var configureConsumers in moduleConfigureConsumers)
			{
				configureConsumers(configure);
			}

			configure.SetKebabCaseEndpointNameFormatter();

			if (builder.Environment.IsDevelopment())
			{
				configure.UsingInMemory(static (context, cfg) =>
				{
					cfg.ConfigureEndpoints(context);
				});
			}
			else
			{
				configure.UsingRabbitMq((context, cfg) =>
				{
					cfg.Host(builder.Configuration.GetConnectionString("servicebus"));

					cfg.ConfigureEndpoints(context);
				});
			}
		});

		return builder;
	}

	public static IHostApplicationBuilder AddDatabase<T>(this IHostApplicationBuilder builder,
		string schema,
		Action<DbContextOptionsBuilder>? dbContextConfigure = null,
		Action<SqlServerDbContextOptionsBuilder>? sqlServerConfigure = null) where T : DbContext
	{
		builder.AddSqlServerDbContext<T>("database");
		builder.Services.AddDbContextPool<T>((sp, options) =>
		{
			options.UseSqlServer(builder.Configuration.GetConnectionString("database"), optionsBuilder =>
			       {
				       optionsBuilder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, schema);
				       sqlServerConfigure?.Invoke(optionsBuilder);
					   optionsBuilder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), [0]);
			       })
			       .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>());
			dbContextConfigure?.Invoke(options);
		});
		builder.EnrichSqlServerDbContext<T>();
		return builder;
	}
}