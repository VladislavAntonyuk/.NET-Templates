namespace App1.Application.UseCases.Class1.Queries.GetClass1;

public class GetClass1ByFilterResponse
{
	public List<Class1Dto> Items { get; set; } = new ();
	public int PageIndex { get; }
	public int TotalPages { get; }
	public int TotalCount { get; }
}