using Persistence.ES.JobScheduler;
using Quartz;

namespace ServiceHost;

public static class QuartzJobService
{
    public static void AddQuartzService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddQuartz(configure =>
        {
            var jobKey = new JobKey(nameof(EventStoreRetrievalJobScheduler));
            configure.AddJob<EventStoreRetrievalJobScheduler>(jobKey)
                .AddTrigger(trigger =>
                    trigger.ForJob(jobKey)
                        .WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(5).RepeatForever()));
            configure.UseMicrosoftDependencyInjectionJobFactory();
        });
        serviceCollection.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);
    }
}