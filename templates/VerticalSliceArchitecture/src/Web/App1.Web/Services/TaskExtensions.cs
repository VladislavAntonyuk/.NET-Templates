namespace App1.Web.Services;

public static class TaskExtensions
{
	public static async Task<T> Safe<T>(this Task<T> task, T defaultValue, Action<Exception> onError)
	{
		try
		{
			return await task;
		}
		catch (Exception e)
		{
			onError(e);
			return defaultValue;
		}
	}

	public static async Task Safe(this Task task, Action<Exception> onError)
	{
		try
		{
			await task;
		}
		catch (Exception e)
		{
			onError(e);
		}
	}
}