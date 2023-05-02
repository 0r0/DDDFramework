using DDDFramework.Domain.Contracts.Order;

namespace DDDFramework.Domain.Order;

public interface ISingleObjectBuilder<out T> where T : class, new()
{
    void With<TProperty>(Func<T, TProperty> func, TProperty value);
    T Build();
}

public class OrderArgs
{
    public OrderArgs()
    {
    }

    private OrderId Id { get; set; }
    private string Title { get; set; }
    private long OrderNumber { get; set; }
    private bool IsActive { get; set; }

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