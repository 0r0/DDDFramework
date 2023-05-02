using DDDFramework.Domain.Order;

namespace DDDFramework.Application.Order;

internal class OrderArgFactory : IOrderArgFactory
{
    public async Task<OrderArgs> CreateFrom(OrderCreatedCommand orderCreated)
    {
        // var orderArg = OrderArgs.Builder.With(a => a.Title, orderCreated.Title)
        //     .With(a => a.IsActive, orderCreated.IsActive)
        //     .With(a => a.OrderNumber, orderCreated.OrderNumber)
        //     .With(a => a.Id, new OrderId(Guid.NewGuid()))
        //     .Build();
        // return await orderArg;
        throw new NotImplementedException();
    }

    public async Task<OrderArgs> CreateFrom(OrderPlacedCommand orderPlaced)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderArgs> CreateFrom(OrderActivatedCommand orderActivated)
    {
        throw new NotImplementedException();
    }
}