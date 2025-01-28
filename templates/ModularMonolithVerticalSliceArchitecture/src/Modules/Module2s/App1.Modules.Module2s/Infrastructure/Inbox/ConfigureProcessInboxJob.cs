using Microsoft.Extensions.Options;
using Quartz;

namespace App1.Modules.Module2s.Infrastructure.Inbox;

internal sealed class ConfigureProcessInboxJob(IOptions<InboxOptions> inboxOptions) : IConfigureOptions<QuartzOptions>
{
	public void Configure(QuartzOptions options)
	{
		var jobName = typeof(ProcessInboxJob).FullName!;

		options.AddJob<ProcessInboxJob>(configure => configure.WithIdentity(jobName))
		       .AddTrigger(configure =>
		       {
			       configure.ForJob(jobName)
			                .WithSimpleSchedule(schedule =>
			                {
				                schedule
					                .WithIntervalInSeconds(inboxOptions.Value.IntervalInSeconds)
					                .RepeatForever();
			                });
		       });
	}
}