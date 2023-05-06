using DDDFramework.Application.Contracts.Orders;

namespace DDDFramework.Tests.Application;

public class OrderArgFactoryTest
{
    [Theory]
    [InlineData("Hassan", 20)]
    [InlineData("Javad", 40)]
    private void order_arg_created_from_create_order_command(string title, long orderNumber)
    {
        var command = new CreateOrderCommand()
        {
            Id = default,
            Title = title,
            IsActive = false,
            OrderNumber = orderNumber
        };
        var argFactory = new OrderArgFactory();
        var orderArg = argFactory.CreateFrom(command);
        Assert.Equal(title,orderArg.Title);
        Assert.Equal(orderNumber,orderArg.OrderNumber);
        Assert.False(orderArg.IsActive);
        
    }
}