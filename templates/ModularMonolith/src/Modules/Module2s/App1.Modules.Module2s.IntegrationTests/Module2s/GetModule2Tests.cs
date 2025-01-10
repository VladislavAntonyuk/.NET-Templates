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
        var module2Result = await Sender.Send(new GetModule2Query(module2Id));

        // Assert
        module2Result.Error.Should().Be(Module2Errors.NotFound(module2Id));
    }

    [Fact]
    public async Task Should_ReturnModule2_WhenModule2Exists()
    {
        // Arrange
        var result = await Sender.Send(new RegisterModule2Command(Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")));
        var module2Id = result.Value.Id;

        // Act
        var module2Result = await Sender.Send(new GetModule2Query(module2Id));

        // Assert
        module2Result.IsSuccess.Should().BeTrue();
        module2Result.Value.Should().NotBeNull();
    }
}
