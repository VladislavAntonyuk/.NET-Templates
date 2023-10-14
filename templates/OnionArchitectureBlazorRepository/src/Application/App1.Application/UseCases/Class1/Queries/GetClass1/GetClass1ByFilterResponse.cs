namespace App1.Application.UseCases.Class1.Queries.GetClass1;

public class GetClass1ByFilterResponse
{
	public List<Class1Dto> Items { get; init; } = [];
	public int TotalCount { get; init; }
}