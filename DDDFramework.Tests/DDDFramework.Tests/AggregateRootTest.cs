using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Domain.Order;
using EventStore.Client;

namespace DDDFramework.Tests;

public class AggregateRootTest
{
    [Fact]
    public void Aggregate_root_Id_should_be_getted_and_setted()
    {
        var a = new AggregateRootImplementation();
        var guid = Guid.NewGuid();
        a.Id = guid;

        Assert.Equal(guid, a.Id);
    }

    [Fact]
    public void AggregateRoot_can_save_unCommittedEvent()
    {
        var orderCreatedDomainEvent = new OrderCreated()
        {
            Title = "coal for m mine",
            OrderNumber = 100
        };

        var aggregate = new AggregateRootImplementation();
        aggregate.AddEvent(orderCreatedDomainEvent);
        var @event = aggregate._uncommittedEvent.First();
        Assert.Equal(@event, orderCreatedDomainEvent);
    }

    // unit test for remove _uncommitted event;
    [Fact]
    public void AggregateRoot_can_remove_unCommitedEvent()
    {
        var orderCreatedDomainEvent = new OrderCreated()
        {
            Title = "coal for m mine",
            OrderNumber = 100
        };
        var orderCreatedDomainEvent2 = new OrderCreated()
        {
            Title = "Iron",
            OrderNumber = 200
        };
        var aggregate = new AggregateRootImplementation();
        aggregate.AddEvent(orderCreatedDomainEvent);
        aggregate.AddEvent(orderCreatedDomainEvent2);
        aggregate.RemoveEvent(orderCreatedDomainEvent);
        Assert.Single(aggregate._uncommittedEvent);
        Assert.DoesNotContain(orderCreatedDomainEvent, aggregate._uncommittedEvent);
    }

    [Fact]
    public void AggregateRoot_can_apply_domainEvent_to_domain()
    {
        var orderCreatedEvent = new OrderCreated()
        {
            Title = "Ali",
            OrderNumber = 11,
        };
        var order = new Order();
    }

    [Fact]
    public void domain_event_set_automatically_eventId_and_version()
    {
        var domainEvent = new OrderCreated();
        Assert.True(domainEvent.EventId != Uuid.Empty);
        Assert.True(domainEvent.Version > 0);
    }
}