namespace App1.Application.UseCases.Class1.Commands.Delete;

using Interfaces.CQRS;

public class DeleteClass1Command : ICommand<bool>
{
	public DeleteClass1Command(int class1Id)
	{
		Class1Id = class1Id;
	}

	public int Class1Id { get; }
}