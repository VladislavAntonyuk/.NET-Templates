namespace App1.Application.UseCases.Class1.Commands.Update;

using Interfaces.CQRS;
using Mediator;

public class UpdateClass1Command(int id) : ICommand<OperationResult>
{
	public int Id { get; } = id;
	public string Name { get; init; } = string.Empty;
}