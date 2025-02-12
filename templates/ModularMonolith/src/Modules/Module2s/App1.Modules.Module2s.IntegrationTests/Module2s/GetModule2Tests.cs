using App1.Modules.Module2s.Application.Module2s.CreateModule2;
using App1.Modules.Module2s.Application.Module2s.GetModule2ById;
using App1.Modules.Module2s.Domain.Module2s;
using App1.Modules.Module2s.IntegrationTests.Abstractions;

namespace App1.Modules.Module2s.IntegrationTests.Module2s;

public class GetModule2Tests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
	[Fact]
    public async Task Should_ReturnError_WhenModule2DoesNotExist()
    {
        // Arrange
        var module2Id = Guid.NewGuid();

        // Act
        var module2Result = await Sender.Send(new GetModule2Query(module2Id), TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(Module2Errors.NotFound(module2Id), module2Result.Error);
    }

    [Fact]
    public async Task Should_ReturnModule2_WhenModule2Exists()
    {
        // Arrange
        var result = await Sender.Send(new CreateModule2Command(Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")), TestContext.Current.CancellationToken);
        var module2Id = result.Value.Id;

        // Act
        var module2Result = await Sender.Send(new GetModule2Query(module2Id), TestContext.Current.CancellationToken);

        // Assert
        Assert.True(module2Result.IsSuccess);
        Assert.NotNull(module2Result.Value);
    }
}
