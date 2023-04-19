using Aggregate;

namespace DDDFramework.Tests;

public class OrderCreated : DomainEvent
{
    public long OrderNumber { get; init; }
    public string Title { get; init; }
}