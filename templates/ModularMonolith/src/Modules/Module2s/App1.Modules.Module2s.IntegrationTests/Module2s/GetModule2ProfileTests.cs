using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using App1.Modules.Module2s.IntegrationTests.Abstractions;
using FluentAssertions;

namespace App1.Modules.Module2s.IntegrationTests.Module2s;

public class GetModule2ProfileTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
	[Fact]
    public async Task Should_ReturnUnauthorized_WhenAccessTokenNotProvided()
    {
		SetAuth(false);

        // Act
        HttpResponseMessage response = await HttpClient.GetAsync("Module2s/profile");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Should_ReturnOk_WhenModule2Exists()
    {
		SetAuth(true);

		// Arrange
        string accessToken = await RegisterModule2AndGetAccessTokenAsync();
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            accessToken);

        // Act
        HttpResponseMessage response = await HttpClient.GetAsync("Module2s/profile");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        Module2Response? module2 = await response.Content.ReadFromJsonAsync<Module2Response>();
        module2.Should().NotBeNull();
    }

    private async Task<string> RegisterModule2AndGetAccessTokenAsync()
    {
        var request = new RegisterModule2.Request
        {
	        ClientId = "3c3bdb4b-327b-49a9-a13e-0b565526b8a1",
	        ObjectId = Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")
		};

        var response = await HttpClient.PostAsJsonAsync("Module2s/register", request);
        response.EnsureSuccessStatusCode();

        string accessToken = string.Empty;

        return accessToken;
    }
}
