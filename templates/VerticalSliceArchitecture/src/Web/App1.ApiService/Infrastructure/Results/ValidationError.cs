namespace App1.ApiService.Infrastructure.Results;

public sealed record ValidationError(Error[] Errors) : Error("General.Validation",
                                                             "One or more validation errors occurred",
                                                             ErrorType.Validation)
{
	public static ValidationError FromResults(IEnumerable<Result> results)
	{
		return new ValidationError(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
	}
}