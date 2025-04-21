namespace App1.ApiService.Infrastructure.Results;

public static class ResultExtensions
{
	public static TOut Match<TOut>(this Result result, Func<TOut> onSuccess, Func<Result, TOut> onFailure)
	{
		return result.IsSuccess ? onSuccess() : onFailure(result);
	}

	public static TOut Match<TIn, TOut>(this Result<TIn> result,
		Func<TIn, TOut> onSuccess,
		Func<Result<TIn>, TOut> onFailure)
	{
		return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
	}
}