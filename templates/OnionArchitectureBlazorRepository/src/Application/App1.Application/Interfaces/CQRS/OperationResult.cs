namespace App1.Application.Interfaces.CQRS;

using System.Diagnostics.CodeAnalysis;

public class OperationResult<T> : OperationResult
{
	public T? Value { get; init; }

	[MemberNotNullWhen(true, nameof(Value))]
	public override bool IsSuccessful => base.IsSuccessful;
}

public class OperationResult
{
	public virtual bool IsSuccessful => Errors.Count == 0;

	public ICollection<Error> Errors { get; } = new List<Error>();
}

public class Error
{
	public required string Description { get; init; }
}