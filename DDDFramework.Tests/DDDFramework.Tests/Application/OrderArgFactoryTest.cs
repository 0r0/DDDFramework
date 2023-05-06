using Aggregate;
using DDDFramework.Application.Contracts.Orders;
using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Domain.Order;

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

    [Theory]
    [InlineData("Hassan", 20)]
    [InlineData("Javad", 40)]
    private void order_arg_activated_when_calling_activate_order_command(string title, long orderNumber)
    {
        var createOrderCommand = new CreateOrderCommand()
        {
            Id = default,
            Title = title,
            IsActive = false,
            OrderNumber = orderNumber
        };
        
        var argFactory = new OrderArgFactory();
        var orderArg = argFactory.CreateFrom(createOrderCommand);
        var activateCommand = new ActivateOrderCommand()
        {
            IsActive = true
        };
        var events = new List<DomainEvent>()
        {
            new OrderCreated()
            {
                Id = orderArg.Id,
                Title = orderArg.Title,
                IsActive = orderArg.IsActive,
                OrderNumber = orderArg.OrderNumber
            },
            new OrderActivated(orderArg.OrderNumber,orderArg.Title)
        };
        
        var aggregateRoot = new AggregateRootFactory().Create<Order>(events);
        Assert.True(aggregateRoot.IsActive);
        Assert.Equal(aggregateRoot.Id.DbId,createOrderCommand.Id);

        //call activatedOrder event then check event and command become activated

    }
    
    [Theory]
    [InlineData("Gizem", 20)]
    [InlineData("Mehdi", 40)]
    private void order_arg_created_from_place_order_command(string title, long orderNumber)
    {}
}