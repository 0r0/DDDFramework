using Aggregate;

namespace DDDFramework.Tests;

public class OrderCreated : DomainEvent
{
    public OrderCreated() => Id = Guid.NewGuid();

    public Guid Id { get; }
    public long OrderNumber { get; init; }

    public string Title { get; init; }
}