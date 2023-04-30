using Aggregate;

namespace DDDFramework.Tests;

public class OrderConfirmed : DomainEvent
{
    public Guid Id { get; init; }
    public long OrderNumber { get; init; }
    public string Title { get; init; }
}