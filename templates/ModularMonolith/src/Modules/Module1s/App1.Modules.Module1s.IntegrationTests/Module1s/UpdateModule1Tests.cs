using App1.Common.Domain;
using App1.Modules.Module1s.Application.Module1s.CreateModule1;
using App1.Modules.Module1s.Application.Module1s.UpdateModule1;
using App1.Modules.Module1s.Domain.Module1s;
using App1.Modules.Module1s.IntegrationTests.Abstractions;

namespace App1.Modules.Module1s.IntegrationTests.Module1s;

public class UpdateModule1Tests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
	public static readonly TheoryData<UpdateModule1Command> InvalidCommands =
	[
		new UpdateModule1Command(Guid.Empty)
	];

    [Theory]
    [MemberData(nameof(InvalidCommands))]
    public async Task Should_ReturnError_WhenCommandIsNotValid(UpdateModule1Command command)
    {
        // Act
        Result result = await Sender.Send(command, TestContext.Current.CancellationToken);

        // Assert
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.Validation, result.Error.Type);
    }

    [Fact]
    public async Task Should_ReturnError_WhenModule1DoesNotExist()
    {
        // Arrange
        var module1Id = Guid.NewGuid();

        // Act
        Result updateResult = await Sender.Send(new UpdateModule1Command(module1Id), TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(Module1Errors.NotFound(module1Id), updateResult.Error);
    }

    [Fact]
    public async Task Should_ReturnSuccess_WhenModule1Exists()
    {
        // Arrange
        var result = await Sender.Send(new CreateModule1Command(Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")), TestContext.Current.CancellationToken);

        Guid module1Id = result.Value.Id;

        // Act
        Result updateResult = await Sender.Send(new UpdateModule1Command(module1Id), TestContext.Current.CancellationToken);

        // Assert
        Assert.True(updateResult.IsSuccess);
    }
}
