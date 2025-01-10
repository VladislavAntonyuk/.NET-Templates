namespace App1.Common.Application.Exceptions;

using Domain;

public sealed class App1Exception(
	string requestName,
	Error? error = default,
	Exception? innerException = default) : Exception("Application exception", innerException)
{
	public string RequestName { get; } = requestName;

	public Error? Error { get; } = error;
}