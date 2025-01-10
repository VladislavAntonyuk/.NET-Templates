using App1.ApiService;
using App1.Modules.Module2s.IntegrationTests.Abstractions.Fixtures;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.MsSql;
using Testcontainers.Redis;

namespace App1.Modules.Module2s.IntegrationTests.Abstractions;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
	private readonly MsSqlContainer dbContainer = new MsSqlBuilder()
	                                              .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
	                                              .Build();

	private readonly RedisContainer redisContainer = new RedisBuilder().WithImage("redis:latest").Build();

	public async Task InitializeAsync()
	{
		await dbContainer.StartAsync();
		await redisContainer.StartAsync();
	}

	public new async Task DisposeAsync()
	{
		await dbContainer.StopAsync();
		await redisContainer.StopAsync();
	}

	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		Environment.SetEnvironmentVariable("ConnectionStrings:database", dbContainer.GetConnectionString());
		Environment.SetEnvironmentVariable("ConnectionStrings:cache", redisContainer.GetConnectionString());
		Environment.SetEnvironmentVariable("ConnectionStrings:ai-llama3-2", "Endpoint=https://localhost;Model=llama3.2");

		builder.ConfigureServices(services =>
		{
			services.AddTransient<IAuthenticationSchemeProvider, MockSchemeProvider>();
			services.Configure<TestAuthHandlerOptions>(options =>
			{
				options.FakeSuccessfulAuthentication = true;
			});
		});
	}
}