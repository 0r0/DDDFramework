using MassTransit;

namespace Aggregate;

public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
{
    public IList<DomainEvent> _uncommitedEvent;
  

    public AggregateRoot()
    {
        
        _uncommitedEvent = new List<DomainEvent>();
    }


    public void AddEvent(DomainEvent @event)

    {
        if (@event is null) throw new ArgumentNullException($"domain event can  not be null=>{nameof(@event)}");
        _uncommitedEvent.Add(@event);
    }

    public virtual void Apply(dynamic @event)
    {
        _uncommitedEvent.Remove(@event);
        
    }
}