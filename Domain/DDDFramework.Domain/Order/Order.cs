using Aggregate;
using DDDFramework.Tests;

namespace DDDFramework.Domain.Order;

public partial class Order : AggregateRoot<OrderId>
{
    public override void Apply(DomainEvent @event)
    {
        When((dynamic)@event);
    }

    public void ApplyAndPublish(DomainEvent @event)
    {
        _uncommitedEvent.Add(@event);
        When((dynamic) @event);
    }

    public void When(OrderCreated @event)
    {
        
    }
}