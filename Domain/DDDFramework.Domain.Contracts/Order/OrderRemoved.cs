using Aggregate;

namespace DDDFramework.Domain.Contracts.Order;

public class OrderRemoved : DomainEvent
{
    public OrderId Id { get; }

    public OrderRemoved(OrderId id)
    {
        Id = id;
    }
}