﻿using Aggregate;
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
            new OrderCreated()
            {
                Title = "Coal",
                Version = 1,
                OrderNumber = 11
            },
            new OrderActivated(),
            new OrderPlaced(11, "Metan")

        };
        //make aggregate root from aggregate factory
        var orderAggregate =new AggregateRootFactory().Create<Order>(events);
      

    }
}