using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ServiceHost;

public class InfrastructureHealthCheck :IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        //todo! implement event store connection health check here
        throw new NotImplementedException();

    }
}