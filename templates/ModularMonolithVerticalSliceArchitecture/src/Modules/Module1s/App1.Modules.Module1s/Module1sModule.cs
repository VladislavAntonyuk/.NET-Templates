﻿using App1.Common.Application.Messaging;
using App1.Common.Infrastructure;
using App1.Common.Presentation.Endpoints;
using App1.Modules.Module1s.Application;
using App1.Modules.Module1s.Infrastructure.Database;
using App1.Modules.Module1s.Infrastructure.Outbox;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App1.Modules.Module1s;

public static class Module1sModule
{
	public static IHostApplicationBuilder AddModule1sModule(this IHostApplicationBuilder builder)
	{
		builder.Services.AddDomainEventHandlers();

		builder.AddInfrastructure();
		builder.Services.AddEndpoints(AssemblyReference.Assembly);

		return builder;
	}

	private static void AddInfrastructure(this IHostApplicationBuilder builder)
	{
		builder.AddDatabase<Module1sDbContext>(Schemas.Module1s, optionsBuilder =>
		{
			optionsBuilder.UseAsyncSeeding(async (dbContext, _, cancellationToken) =>
			{
				var module1Guid = Guid.CreateVersion7();
				var module1 = dbContext.Find<Module1>(module1Guid);
				if (module1 != null)
				{
					return;
				}

				dbContext.Add(Module1.Create(Guid.CreateVersion7()));
				await dbContext.SaveChangesAsync(cancellationToken);
			});
		});

		builder.Services.Configure<OutboxOptions>(builder.Configuration.GetSection("Module1s:Outbox"));

		builder.Services.ConfigureOptions<ConfigureProcessOutboxJob>();
	}

	private static void AddDomainEventHandlers(this IServiceCollection services)
	{
		var domainEventHandlers = AssemblyReference.Assembly.GetTypes()
		                                     .Where(t => t.IsAssignableTo(typeof(IDomainEventHandler)));

		foreach (var domainEventHandler in domainEventHandlers)
		{
			services.AddKeyedScoped(typeof(IDomainEventHandler), GetKey(domainEventHandler), domainEventHandler);
		}
		
		static string GetKey(Type type)
		{
			const int handlerNameSuffixLength = 7;
			return type.Name.AsSpan(..^handlerNameSuffixLength).ToString();
		}
	}
}