using App1.Modules.Module2s.IntegrationTests.Abstractions;
using AutoFixture;

namespace App1.Modules.Module2s.IntegrationTests.Module2s;

public class UpdateModule2Tests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
	public static readonly TheoryData<UpdateModule2Command> InvalidCommands =
	[
		new UpdateModule2Command(Guid.Empty, Faker.Create<bool>())
	];

    [Theory]
    [MemberData(nameof(InvalidCommands))]
    public async Task Should_ReturnError_WhenCommandIsNotValid(UpdateModule2Command command)
    {
        // Act
        Result result = await Sender.Send(command);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Type.Should().Be(ErrorType.Validation);
    }

    [Fact]
    public async Task Should_ReturnError_WhenModule2DoesNotExist()
    {
        // Arrange
        var module2Id = Guid.NewGuid();

        // Act
        Result updateResult = await Sender.Send(
            new UpdateModule2Command(module2Id, Faker.Create<bool>()));

        // Assert
        updateResult.Error.Should().Be(Module2Errors.NotFound(module2Id));
    }

    [Fact]
    public async Task Should_ReturnSuccess_WhenModule2Exists()
    {
        // Arrange
        var result = await Sender.Send(new RegisterModule2Command(Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")));

        Guid module2Id = result.Value.Id;

        // Act
        Result updateResult = await Sender.Send(
            new UpdateModule2Command(module2Id, Faker.Create<bool>()));

        // Assert
        updateResult.IsSuccess.Should().BeTrue();
    }
}
