using Aggregate;
using DDDFramework.Domain.Contracts.Order;

namespace DDDFramework.Domain.Order;

public partial class Order
{
    public override void Apply(DomainEvent @event)
    {
        When((dynamic)@event);
    }
    

    public void When(OrderCreated @event)
    {
        Id = @event.Id;
    }

    public void When(OrderActivated @event)
    {
        IsActive = true;
    }

    public void When(OrderPlaced @event)
    {
    }

    public void When(OrderInfoUpdated @event)
    {
    }
}