using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using App1.Modules.Module2s.Application.Module2s.GetModule2ById;
using App1.Modules.Module2s.IntegrationTests.Abstractions;
using App1.Modules.Module2s.Presentation.Module2s;

namespace App1.Modules.Module2s.IntegrationTests.Module2s;

public class GetModule2ProfileTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
	[Fact]
    public async Task Should_ReturnUnauthorized_WhenAccessTokenNotProvided()
    {
		SetAuth(false);

        // Act
        HttpResponseMessage response = await HttpClient.GetAsync("Module2s/19d3b2c7-8714-4851-ac73-95aeecfba3a7", TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Should_ReturnOk_WhenModule2Exists()
    {
		SetAuth(true);

		// Arrange
        string id = await RegisterModule2AndGetAccessTokenAsync();

        // Act
        HttpResponseMessage response = await HttpClient.GetAsync($"Module2s/{id}", TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        Module2Response? module2 = await response.Content.ReadFromJsonAsync<Module2Response>(TestContext.Current.CancellationToken);
        Assert.NotNull(module2);
    }

    private async Task<string> RegisterModule2AndGetAccessTokenAsync()
    {
        var request = new CreateModule2.Request
        {
	        ObjectId = Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")
		};

        var response = await HttpClient.PostAsJsonAsync("Module2s", request);
        response.EnsureSuccessStatusCode();

        return "19d3b2c7-8714-4851-ac73-95aeecfba3a6";
    }
}
