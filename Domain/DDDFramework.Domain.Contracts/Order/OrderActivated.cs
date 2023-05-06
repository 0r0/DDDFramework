namespace DDDFramework.Domain.Contracts.Order;

public class OrderActivated : OrderPlaced
{
    

    public void ActivateOrder() => IsActive = true;

    public OrderActivated(long orderNumber, string title) : base(orderNumber, title)
    {
        ActivateOrder();
    }
}