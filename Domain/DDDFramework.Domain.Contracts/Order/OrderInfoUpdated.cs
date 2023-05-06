using Aggregate;

namespace DDDFramework.Domain.Contracts.Order;

public class OrderInfoUpdated :DomainEvent
{
    public OrderInfoUpdated(string title)
    {
        Title = title;
    }

    public string Title { get;  }
}