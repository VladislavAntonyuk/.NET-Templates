using App1.Common.Application.Messaging;
using App1.Common.Infrastructure;
using App1.Common.Presentation.Endpoints;
using App1.Modules.Module2s.Application.Module2;
using App1.Modules.Module2s.Infrastructure.Database;
using App1.Modules.Module2s.Infrastructure.Inbox;
using App1.Modules.Module2s.Infrastructure.Outbox;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App1.Modules.Module2s;

public static class Module2sModule
{
	public static IHostApplicationBuilder AddModule2sModule(this IHostApplicationBuilder builder)
	{
		builder.Services.AddDomainEventHandlers();

		builder.AddInfrastructure();
		builder.Services.AddEndpoints(AssemblyReference.Assembly);

		return builder;
	}

	public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator)
	{
		registrationConfigurator.AddConsumers(typeof(Module2sModule).Assembly);
	}

	private static void AddInfrastructure(this IHostApplicationBuilder builder)
	{
		builder.AddDatabase<Module2sDbContext>(Schemas.Module2s, optionsBuilder =>
		{
			optionsBuilder.UseAsyncSeeding(async (dbContext, _, cancellationToken) =>
			{
				var module2Guid = Guid.CreateVersion7();
				var module2 = dbContext.Find<Module2>(module2Guid);
				if (module2 != null)
				{
					return;
				}

				dbContext.Add(Module2.Create(Guid.CreateVersion7()));
				await dbContext.SaveChangesAsync(cancellationToken);
			});
		});
		builder.Services.Configure<InboxOptions>(builder.Configuration.GetSection("Module2s:Inbox"));

		builder.Services.ConfigureOptions<ConfigureProcessInboxJob>();

		builder.Services.Configure<OutboxOptions>(builder.Configuration.GetSection("Module2s:Outbox"));

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