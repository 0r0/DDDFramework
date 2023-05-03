namespace DDDFramework.Domain.Contracts.Order;

public class OrderActivated : OrderPlaced
{
    public OrderActivated()
    {
        ActivateOrder();
    }

    public void ActivateOrder() => IsActive = true;
}