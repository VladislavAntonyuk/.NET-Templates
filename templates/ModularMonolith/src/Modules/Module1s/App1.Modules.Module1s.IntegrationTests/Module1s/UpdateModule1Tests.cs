using App1.Common.Domain;
using App1.Modules.Module1s.Application.Module1s.CreateModule1;
using App1.Modules.Module1s.Application.Module1s.UpdateModule1;
using App1.Modules.Module1s.Domain.Module1s;
using App1.Modules.Module1s.IntegrationTests.Abstractions;
using AutoFixture;
using FluentAssertions;

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
        Result result = await Sender.Send(command);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Type.Should().Be(ErrorType.Validation);
    }

    [Fact]
    public async Task Should_ReturnError_WhenModule1DoesNotExist()
    {
        // Arrange
        var module1Id = Guid.NewGuid();

        // Act
        Result updateResult = await Sender.Send(
            new UpdateModule1Command(module1Id));

        // Assert
        updateResult.Error.Should().Be(Module1Errors.NotFound(module1Id));
    }

    [Fact]
    public async Task Should_ReturnSuccess_WhenModule1Exists()
    {
        // Arrange
        var result = await Sender.Send(new CreateModule1Command(Guid.Parse("19d3b2c7-8714-4851-ac73-95aeecfba3a6")));

        Guid module1Id = result.Value.Id;

        // Act
        Result updateResult = await Sender.Send(
            new UpdateModule1Command(module1Id));

        // Assert
        updateResult.IsSuccess.Should().BeTrue();
    }
}
