using Aggregate;

namespace DDDFramework.Tests;

public class OrderPlaced : DomainEvent
{
    protected OrderPlaced()
    {
        
    }

    public OrderPlaced(long orderNumber, string title)
    {
        OrderNumber = orderNumber;
        Title = title;
    }

    public OrderId Id { get; private set; }
    public long OrderNumber { get; }
    public string Title { get; }
    public bool IsActive { get; protected set; }
}