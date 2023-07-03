using DDDFramework.Core.Application.Contracts;
using DDDFramework.Domain.Contracts.Order;
using MongoDB.Bson;
using MongoDB.Driver;


namespace MongoDBSynchronizer.Handlers;

public class OrderEventHandlers : IEventHandler<OrderCreated>

{
    private readonly IMongoCollection<BsonDocument> _mongoCollection;

    public OrderEventHandlers(IMongoCollection<BsonDocument> mongoCollection)
    {
        _mongoCollection = mongoCollection;
    }

    public async Task Handle(OrderCreated @event)
    {
        
        await Task.CompletedTask;
    }
}