using System.Net;
using System.Net.Http.Json;
using App1.Modules.Module1s.IntegrationTests.Abstractions;
using App1.Modules.Module1s.Presentation.Module1s;

namespace App1.Modules.Module1s.IntegrationTests.Module1s;

public class RegisterModule1Tests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
	public static readonly TheoryData<string> InvalidRequests = ["19d3b2c7-8714-4851-ac73-95aeecfba3a6"];


    [Theory]
    [MemberData(nameof(InvalidRequests))]
    public async Task Should_ReturnUnauthorized_WhenRequestIsNotValid(string objectId)
    {
		SetAuth(true);

        // Arrange
        var request = new CreateModule1.Request
        {
	        ObjectId = Guid.Parse(objectId)
		};

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Module1s", request, TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }


    [Fact]
    public async Task Should_ReturnBadRequest_WhenRequestIsNull()
    {
		SetAuth(true);

		// Arrange
		CreateModule1.Request? request = null;

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Module1s", request, TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Should_ReturnOk_WhenRequestIsValid()
    {
		SetAuth(true);

		// Arrange
		var request = new CreateModule1.Request
        {
	        ObjectId = Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")
        };

        // Act
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Module1s", request, TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
