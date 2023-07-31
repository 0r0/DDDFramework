using Aggregate;
using Aggregate.AggregateRootFactory;
using DDDFramework.Application;
using DDDFramework.Domain;
using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Domain.Order;

namespace DDDFramework.Tests;

public class AggregateRootFactoryTest
{
    [Fact]
    public void can_make_aggregate_root_from_events_stored_in_event_store_by_using_aggregateRootFactory()
    {
        var events = new List<DomainEvent>()
        {
            new OrderCreated(
                title: "Coal",
                isActive: false,
                orderNumber: 11,
                id: new OrderId(Guid.NewGuid())),
            new OrderActivated(),
            new OrderPlaced(11, "Metan"),
            new OrderInfoUpdated("Sadam Yazid Kaffar")
        };
        //make aggregate root from aggregate factory
        var orderAggregate = new AggregateRootFactory().Create<Order>(events);
    }
}