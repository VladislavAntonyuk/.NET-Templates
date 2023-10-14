namespace App1.Application.UseCases.Class1.Queries.GetClass1;

using Models;

public class GetClass1ByFilterResponse
{
	public List<Class1Dto> Items { get; set; } = new();
	public int PageIndex { get; init; }
	public int TotalPages { get; init; }
	public int TotalCount { get; init; }
}