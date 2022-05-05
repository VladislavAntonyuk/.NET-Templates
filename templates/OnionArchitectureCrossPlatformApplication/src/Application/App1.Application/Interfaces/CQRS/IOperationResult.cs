namespace App1.Application.Interfaces.CQRS;

using System.Diagnostics.CodeAnalysis;

public interface IOperationResult<out T>
{
	T? Value { get; }

	[MemberNotNullWhen(true, "Value")]
	bool IsSuccessful { get; }

	ICollection<string> Errors { get; }
}