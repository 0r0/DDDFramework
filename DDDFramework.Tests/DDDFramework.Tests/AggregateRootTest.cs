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
    public void AggregateRoot_can_save_unCommitedEvent()
    {
        var orderCreatedDomainEvent = new OrderCreated()
        {
            Title = "coal for m mine",
            Version = 1,
            EventId = Guid.NewGuid(),
            OrderNumber = 100
        };
        var aggregate = new AggregateRootImplementation();
        aggregate.AddEvent(orderCreatedDomainEvent);
        var @event = aggregate._uncommitedEvent.First();
        Assert.Equal(@event,orderCreatedDomainEvent);
    }
    
   // unit test for remove _uncommited event;
   [Fact]
   public void AggregateRoot_can_remove_unCommitedEvent()
   {
       var orderCreatedDomainEvent = new OrderCreated()
       {
           Title = "coal for m mine",
           Version = 1,
           EventId = Guid.NewGuid(),
           OrderNumber = 100
       };
       var orderCreatedDomainEvent2 = new OrderCreated()
       {
           Title = "brilliant",
           Version = 1,
           EventId = Guid.NewGuid(),
           OrderNumber = 20
       };
       var aggregate = new AggregateRootImplementation();
       aggregate.AddEvent(orderCreatedDomainEvent);
       aggregate.AddEvent(orderCreatedDomainEvent2);
       aggregate.RemoveEvent(orderCreatedDomainEvent);
       Assert.Equal(aggregate._uncommitedEvent.Count,1);
       Assert.False(aggregate._uncommitedEvent.Contains(orderCreatedDomainEvent));
   }
    
}