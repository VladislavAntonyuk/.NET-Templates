namespace App1.Application.UseCases.Class1.Queries.GetClass1;

public class GetClass1ByFilterResponse
{
	public IReadOnlyCollection<Class1Dto> Items { get; set; } = new List<Class1Dto>();
	public int PageIndex { get; }
	public int TotalPages { get; }
	public int TotalCount { get; }
}