using System.Net;
using System.Net.Http.Json;
using App1.Modules.Module2s.IntegrationTests.Abstractions;
using FluentAssertions;

namespace App1.Modules.Module2s.IntegrationTests.Module2s;

public class RegisterModule2Tests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
	public static readonly TheoryData<string, string> InvalidRequests = new()
    {
	    {"", "19d3b2c7-8714-4851-ac73-95aeecfba3a6"}
	};


    [Theory]
    [MemberData(nameof(InvalidRequests))]
    public async Task Should_ReturnUnauthorized_WhenRequestIsNotValid(
        string clientId,
        string objectId)
    {
		SetAuth(true);

        // Arrange
        var request = new RegisterModule2.Request
        {
	        ClientId = clientId,
	        ObjectId = Guid.Parse(objectId)
		};

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Module2s/register", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }


    [Fact]
    public async Task Should_ReturnBadRequest_WhenRequestIsNull()
    {
		SetAuth(true);

		// Arrange
		RegisterModule2.Request? request = null;

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Module2s/register", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Should_ReturnOk_WhenRequestIsValid()
    {
		SetAuth(true);

		// Arrange
		var request = new RegisterModule2.Request
        {
	        ClientId = "3c3bdb4b-327b-49a9-a13e-0b565526b8a1",
	        ObjectId = Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")
        };

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Module2s/register", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
