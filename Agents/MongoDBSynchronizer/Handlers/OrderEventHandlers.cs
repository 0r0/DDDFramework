using DDDFramework.Core.Application.Contracts;
using DDDFramework.Domain.Contracts.Order;
using MongoDB.Driver;
using MongoDBSynchronizer.MongoDtos;

namespace MongoDBSynchronizer.Handlers;

public class OrderEventHandlers : IEventHandler<OrderCreated>

{
    private readonly IMongoDatabase _mongoDatabase;

    public OrderEventHandlers(IMongoDatabase mongoDatabase)
    {
        _mongoDatabase = mongoDatabase;
    }

    public async Task Handle(OrderCreated @event)
    {
        _mongoDatabase.GetCollection<OrderDto>("OrderDto");
        await Task.CompletedTask;
    }
}