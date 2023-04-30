namespace DDDFramework.Tests;

public class OrderActivated : OrderPlaced
{
    public OrderActivated()
    {
        ActivateOrder();
    }

    public void ActivateOrder() => IsActive = true;
}