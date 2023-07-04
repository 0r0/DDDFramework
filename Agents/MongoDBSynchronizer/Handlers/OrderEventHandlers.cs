using DDDFramework.Core.Application.Contracts;
using DDDFramework.Domain.Contracts.Order;
using MongoDB.Driver;
using MongoDBSynchronizer.MongoDtos;

namespace MongoDBSynchronizer.Handlers;

public class OrderEventHandlers : IEventHandler<OrderCreated>

{
    private readonly IMongoCollection<OrderDto> _mongoCollection;

    public OrderEventHandlers(IMongoCollection<OrderDto> mongoCollection)
    {
        _mongoCollection = mongoCollection;
    }

    public async Task Handle(OrderCreated @event)
    {
        await Task.CompletedTask;
    }
}