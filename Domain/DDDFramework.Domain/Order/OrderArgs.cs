using DDDFramework.Domain.Contracts.Order;
using FizzWare.NBuilder;

namespace DDDFramework.Domain.Order;

public class OrderArgs
{
    public OrderArgs()
    {
    }

    public OrderId Id { get; set; }
    public string Title { get; set; }
    public long OrderNumber { get; set; }
    public bool IsActive { get; set; }

    public static ISingleObjectBuilder<OrderArgs> Builder
        => new Builder().CreateNew<OrderArgs>();

    public void With(OrderId id)
    {
        Id = id;
    }

    public void With(string title)
    {
        Title = title;
    }

    public void With(long orderNumber)
    {
        OrderNumber = orderNumber;
    }

    public void With(bool isActive)
    {
        IsActive = isActive;
    }

    public OrderArgs Build()
    {
        return this;
    }

    //todo! make a builder here
    // var order = new OrderArgs.With 
}