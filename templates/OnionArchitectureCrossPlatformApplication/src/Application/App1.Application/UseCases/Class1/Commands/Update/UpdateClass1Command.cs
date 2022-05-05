namespace App1.Application.UseCases.Class1.Commands.Update;

using Interfaces.CQRS;

public class UpdateClass1Command : ICommand<Class1Dto>
{
	public UpdateClass1Command(int class1Id)
	{
		Class1Id = class1Id;
	}

	public int Class1Id { get; }
	public string Name { get; init; } = string.Empty;
}
