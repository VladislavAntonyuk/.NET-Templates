using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace App1.Common.Infrastructure;

public static class JobExtensions
{
	public static void AddJob<T>(this IServiceCollection services, Func<IServiceProvider, int> intervalInSeconds) where T : IJob
	{
		var jobName = typeof(T).FullName!;
		services.AddQuartz(q => q.AddJob<T>(configure => configure.WithIdentity(jobName))
		                         .AddTrigger((serviceProvider, configure) =>
		                         {
			                         configure.ForJob(jobName)
			                                  .WithSimpleSchedule(schedule =>
			                                  {
				                                  schedule.WithInterval(
					                                          TimeSpan.FromSeconds(
						                                          intervalInSeconds(serviceProvider)))
				                                          .RepeatForever();
			                                  });
		                         }));
	}
}