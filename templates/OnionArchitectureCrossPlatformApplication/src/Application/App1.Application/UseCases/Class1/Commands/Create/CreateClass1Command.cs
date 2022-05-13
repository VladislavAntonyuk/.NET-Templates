namespace App1.Application.UseCases.Class1.Commands.Create;

using Interfaces.CQRS;

public class CreateClass1Command : ICommand<Class1Dto>
{
	public string Name { get; init; } = string.Empty;
}