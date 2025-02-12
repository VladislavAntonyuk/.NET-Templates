using System.Net;
using System.Net.Http.Json;
using App1.Modules.Module2s.IntegrationTests.Abstractions;
using App1.Modules.Module2s.Presentation.Module2s;

namespace App1.Modules.Module2s.IntegrationTests.Module2s;

public class RegisterModule2Tests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
	public static readonly TheoryData<string> InvalidRequests = [""];


    [Theory]
    [MemberData(nameof(InvalidRequests))]
    public async Task Should_ReturnUnauthorized_WhenRequestIsNotValid(string objectId)
    {
		SetAuth(true);

        // Arrange
        var request = new CreateModule2.Request
        {
	        ObjectId = Guid.Parse(objectId)
		};

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Module2s", request, TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }


    [Fact]
    public async Task Should_ReturnBadRequest_WhenRequestIsNull()
    {
		SetAuth(true);

		// Arrange
		CreateModule2.Request? request = null;

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Module2s", request, TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Should_ReturnOk_WhenRequestIsValid()
    {
		SetAuth(true);

		// Arrange
		var request = new CreateModule2.Request
        {
	        ObjectId = Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")
        };

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Module2s", request, TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
