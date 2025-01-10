using App1.Modules.Module1s.Infrastructure.Database;
using App1.Modules.Module1s.IntegrationTests.Abstractions.Fixtures;
using AutoFixture;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace App1.Modules.Module1s.IntegrationTests.Abstractions;

[Collection(nameof(IntegrationTestCollection))]
public abstract class BaseIntegrationTest : IDisposable
{
	protected static readonly Fixture Faker = new();
	protected readonly Module1sDbContext DbContext;
	protected readonly HttpClient HttpClient;
	private readonly IServiceScope scope;
	protected readonly ISender Sender;
	private bool disposedValue;

	protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
	{
		scope = factory.Services.CreateScope();
		HttpClient = factory.CreateClient();
		Sender = scope.ServiceProvider.GetRequiredService<ISender>();
		DbContext = scope.ServiceProvider.GetRequiredService<Module1sDbContext>();
	}

	protected void SetAuth(bool enableAuth, bool failPermission = false)
	{
		var testAuthHandlerOptions = scope.ServiceProvider.GetRequiredService<IOptionsMonitor<TestAuthHandlerOptions>>();
		testAuthHandlerOptions.CurrentValue.FakeSuccessfulAuthentication = enableAuth;
		testAuthHandlerOptions.CurrentValue.FailPermission = failPermission;
	}

	protected async Task CleanDatabaseAsync()
	{
		await DbContext.Database.ExecuteSqlRawAsync("""
		                                            DELETE FROM Module1s.inbox_messages;
		                                            DELETE FROM Module1s.outbox_messages;
		                                            DELETE FROM Module1s.Module1s;
		                                            """);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				scope.Dispose();
			}

			disposedValue = true;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}