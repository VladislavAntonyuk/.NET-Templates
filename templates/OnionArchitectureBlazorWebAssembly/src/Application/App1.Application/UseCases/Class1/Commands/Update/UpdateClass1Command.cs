namespace App1.Application.UseCases.Class1.Commands.Update;

using Interfaces.CQRS;

public class UpdateClass1Command : ICommand<Class1Dto>
{
	public UpdateClass1Command(int id)
	{
		Id = id;
	}

	public int Id { get; }
	public string Title { get; init; } = string.Empty;
}