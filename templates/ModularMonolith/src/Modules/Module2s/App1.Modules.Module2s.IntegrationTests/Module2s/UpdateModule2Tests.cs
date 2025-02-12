using App1.Common.Domain;
using App1.Modules.Module2s.Application.Module2s.CreateModule2;
using App1.Modules.Module2s.Application.Module2s.UpdateModule2;
using App1.Modules.Module2s.Domain.Module2s;
using App1.Modules.Module2s.IntegrationTests.Abstractions;

namespace App1.Modules.Module2s.IntegrationTests.Module2s;

public class UpdateModule2Tests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
	public static readonly TheoryData<UpdateModule2Command> InvalidCommands =
	[
		new UpdateModule2Command(Guid.Empty)
	];

    [Theory]
    [MemberData(nameof(InvalidCommands))]
    public async Task Should_ReturnError_WhenCommandIsNotValid(UpdateModule2Command command)
    {
        // Act
        Result result = await Sender.Send(command, TestContext.Current.CancellationToken);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.Validation, result.Error.Type);
    }

    [Fact]
    public async Task Should_ReturnError_WhenModule2DoesNotExist()
    {
        // Arrange
        var module2Id = Guid.NewGuid();

        // Act
        Result updateResult = await Sender.Send(new UpdateModule2Command(module2Id), TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(Module2Errors.NotFound(module2Id), updateResult.Error);
    }

    [Fact]
    public async Task Should_ReturnSuccess_WhenModule2Exists()
    {
        // Arrange
        var result = await Sender.Send(new CreateModule2Command(Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")), TestContext.Current.CancellationToken);

        Guid module2Id = result.Value.Id;

        // Act
        Result updateResult = await Sender.Send(new UpdateModule2Command(module2Id), TestContext.Current.CancellationToken);

        // Assert
        Assert.True(updateResult.IsSuccess);
    }
}
