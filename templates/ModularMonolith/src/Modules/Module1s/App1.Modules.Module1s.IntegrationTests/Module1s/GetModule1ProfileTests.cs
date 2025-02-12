using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using App1.Modules.Module1s.Application.Module1s.CreateModule1;
using App1.Modules.Module1s.IntegrationTests.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace App1.Modules.Module1s.IntegrationTests.Module1s;

public class GetModule1ByIdTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
	[Fact]
    public async Task Should_ReturnUnauthorized_WhenAccessTokenNotProvided()
    {
		SetAuth(false);

        // Act
        HttpResponseMessage response = await HttpClient.GetAsync("Module1s/3c3bdb4b-327b-49a9-a13e-0b565526b8a1", TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Should_ReturnOk_WhenModule1Exists()
    {
		SetAuth(true);

		// Arrange
        string accessToken = await RegisterModule1AndGetAccessTokenAsync();
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            accessToken);

        // Act
        HttpResponseMessage response = await HttpClient.GetAsync("Module1s/3c3bdb4b-327b-49a9-a13e-0b565526b8a1", TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        Module1Response? module1 = await response.Content.ReadFromJsonAsync<Module1Response>(TestContext.Current.CancellationToken);
        Assert.NotNull(module1);
    }

    private async Task<string> RegisterModule1AndGetAccessTokenAsync()
    {
        var request = new Presentation.Module1s.CreateModule1.Request
        {
	        ObjectId = Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")
		};

        var response = await HttpClient.PostAsJsonAsync("Module1s", request, TestContext.Current.CancellationToken);
        response.EnsureSuccessStatusCode();

        string accessToken = string.Empty;

        return accessToken;
    }
}
