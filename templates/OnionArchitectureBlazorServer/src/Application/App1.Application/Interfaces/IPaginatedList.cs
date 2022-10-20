namespace App1.Application.Interfaces;

public interface IPaginatedList<out T>
{
	IReadOnlyCollection<T> Items { get; }
	int PageIndex { get; }
	int TotalPages { get; }
	int TotalCount { get; }
}