using DDDFramework.Core.Application.Contracts;
using DDDFramework.Domain.Contracts.Order;

namespace MongoDBSynchronizer.Handlers;

public class OrderEventHandlers : IEventHandler<OrderCreated>

{
    public async Task Handle(OrderCreated @event)
    {
        await Task.CompletedTask;
    }
}