using DDDFramework.Application.Contracts.Orders;
using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Domain.Order;
using FizzWare.NBuilder;

namespace DDDFramework.Tests.Application;

public class OrderArgFactory : IOrderArgFactory
{
    public OrderArgs CreateFrom(CreateOrderCommand command)
    {
        command.Id = OrderId.New().DbId;
        var orderArgs = OrderArgs.Builder
            .With(a => a.Id, new OrderId(command.Id))
            .With(a => a.Title, command.Title)
            .With(a => a.OrderNumber, command.OrderNumber)
            .With(a => a.IsActive, command.IsActive)
            .Build();
        return orderArgs;
    }

    public OrderArgs CreateFrom(PlaceOrderCommand command)
    {
        throw new NotImplementedException();
    }

    public OrderArgs CreateFrom(UpdateOrderInfoCommand command)
    {
        throw new NotImplementedException();
    }
}