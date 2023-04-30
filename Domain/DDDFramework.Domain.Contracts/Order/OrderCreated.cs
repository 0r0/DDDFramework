using Aggregate;

namespace DDDFramework.Tests;

public class OrderCreated : DomainEvent
{
    public OrderCreated()
    {
        
    }

  
    public long OrderNumber { get; init; }

    public string Title { get; init; }
    
    public bool IsActive { get; set; }
}