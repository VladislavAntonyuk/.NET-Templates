using App1.Modules.Module1s.Application.Module1s.CreateModule1;
using App1.Modules.Module1s.Application.Module1s.GetModule1ById;
using App1.Modules.Module1s.Domain.Module1s;
using App1.Modules.Module1s.IntegrationTests.Abstractions;

namespace App1.Modules.Module1s.IntegrationTests.Module1s;

public class GetModule1Tests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
	[Fact]
    public async Task Should_ReturnError_WhenModule1DoesNotExist()
    {
        // Arrange
        var module1Id = Guid.NewGuid();

        // Act
        var module1Result = await Sender.Send(new GetModule1Query(module1Id), TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(module1Result.Error, Module1Errors.NotFound(module1Id));
    }

    [Fact]
    public async Task Should_ReturnModule1_WhenModule1Exists()
    {
        // Arrange
        var result = await Sender.Send(new CreateModule1Command(Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")), TestContext.Current.CancellationToken);
        var module1Id = result.Value.Id;

        // Act
        var module1Result = await Sender.Send(new GetModule1Query(module1Id), TestContext.Current.CancellationToken);

        // Assert
        Assert.True(module1Result.IsSuccess);
        Assert.NotNull(module1Result.Value);
    }
}
