using Aggregate;

namespace DDDFramework.Tests;

public class OrderCreated : DomainEvent
{
    public long OrderNumber { get; set; }
    public string Title { get; set; }
}