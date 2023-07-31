using Quartz;

namespace ServiceHost;

public static class QuartzJobService
{
    public static void AddQuartzService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddQuartz(configure =>
            configure.UseMicrosoftDependencyInjectionJobFactory());
        serviceCollection.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);
    }
}