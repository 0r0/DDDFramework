using DDDFramework.Core.Application.Contracts;
using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Query.Contracts;
using MongoDB.Driver;

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