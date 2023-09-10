namespace App1.Application.UseCases;

using System.Diagnostics.CodeAnalysis;
using Interfaces.CQRS;

public record OperationResult<T> : IOperationResult<T>
{
	public T? Value { get; init; }

	[MemberNotNullWhen(true, nameof(Value))]
	public bool IsSuccessful => Errors.Count == 0;

	public ICollection<string> Errors { get; } = new List<string>();
}