namespace App1.Application.UseCases.Class1.Commands.Delete;

using Interfaces.CQRS;
using Mediator;

public class DeleteClass1Command(int class1Id) : ICommand<OperationResult>
{
	public int Class1Id { get; } = class1Id;
}