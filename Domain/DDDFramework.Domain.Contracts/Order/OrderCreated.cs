using Aggregate;

namespace DDDFramework.Domain.Contracts.Order;

public class OrderCreated : DomainEvent
{
    public OrderCreated(OrderId id, long orderNumber, string title, bool isActive)
    {
        Id = id;
        OrderNumber = orderNumber;
        Title = title;
        IsActive = isActive;
    }

    public OrderCreated()
    {
    }

    public OrderId Id { get; set; }
    public long OrderNumber { get; init; }

    public string Title { get; init; }

    public bool IsActive { get; set; }
}