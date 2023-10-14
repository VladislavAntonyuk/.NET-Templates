namespace App1.Application.UseCases.Class1.Commands.Create;

using Interfaces.CQRS;
using Mediator;
using Models;

public class CreateClass1Command : ICommand<OperationResult<Class1Dto>>
{
	public string Name { get; init; } = string.Empty;
}