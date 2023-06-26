using EventStore.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ServiceHost;

public class InfrastructureHealthCheckEventStore : IHealthCheck,IDisposable
{
    private readonly string? _connectionString;
    private readonly EventStoreClient _client;

    public InfrastructureHealthCheckEventStore(string? connectionString)
    {
        ArgumentNullException.ThrowIfNull(_connectionString);
        _client = new EventStoreClient(EventStoreClientSettings
            .Create(_connectionString));
        _connectionString = connectionString;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (string.IsNullOrEmpty(_connectionString))
            return new HealthCheckResult(context.Registration.FailureStatus,
                "event store connection address is not defined");

        return await _client.ReadAllAsync(Direction.Forwards, Position.Start, 1, cancellationToken: cancellationToken)
            .Messages.AnyAsync(cancellationToken)
            ? HealthCheckResult.Healthy("event store connection is existed")
            : new HealthCheckResult(context.Registration.FailureStatus, "Failed to connect to EventStore.");
    }
    public void Dispose() => _client.Dispose();

}