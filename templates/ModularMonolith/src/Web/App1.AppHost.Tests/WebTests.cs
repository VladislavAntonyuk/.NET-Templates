using Projects;

namespace App1.AppHost.Tests;

public class WebTests
{
	[Fact]
	public async Task GetWebResourceRootReturnsOkStatusCode()
	{
		// Arrange
		var appHost = await DistributedApplicationTestingBuilder.CreateAsync<App1_AppHost>(TestContext.Current.CancellationToken);
		appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
		{
			clientBuilder.AddStandardResilienceHandler();
		});
		// To output logs to the xUnit.net ITestOutputHelper, consider adding a package from https://www.nuget.org/packages?q=xunit+logging

		await using var app = await appHost.BuildAsync(TestContext.Current.CancellationToken);
		var resourceNotificationService = app.Services.GetRequiredService<ResourceNotificationService>();
		await app.StartAsync(TestContext.Current.CancellationToken);

		// Act
		var httpClient = app.CreateHttpClient("webfrontend");
		await resourceNotificationService.WaitForResourceAsync("webfrontend", KnownResourceStates.Running, TestContext.Current.CancellationToken)
		                                 .WaitAsync(TimeSpan.FromSeconds(30), TestContext.Current.CancellationToken);
		var response = await httpClient.GetAsync("/", TestContext.Current.CancellationToken);

		// Assert
		Assert.Equal(HttpStatusCode.OK, response.StatusCode);
	}
}