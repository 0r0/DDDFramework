namespace Aggregate;

public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
{
    public List<DomainEvent> _uncommitedEvent;

    public long Version { get; private set; }

    protected AggregateRoot()
    {
        _uncommitedEvent = new List<DomainEvent>();
    }

    public IReadOnlyList<DomainEvent> GetUncommittedEvents() => _uncommitedEvent.AsReadOnly();


    public void AddEvent(DomainEvent @event)

    {
        if (@event is null) throw new ArgumentNullException($"domain event can  not be null=>{nameof(@event)}");
        _uncommitedEvent.Add(@event);
    }

    public virtual void RemoveEvent(DomainEvent @event)
    {
        if (@event is null) throw new ArgumentNullException($"domain event can  not be null=>{nameof(@event)}");

        _uncommitedEvent.Remove(@event);
    }

    public void UpdateVersion() => ++Version;

    public void SetAggregateVersion() => ++Version;
    public void SetDomainEventVersion(DomainEvent @event) => @event.Version = Version + 1L;
    public void ClearUncommittedEvent() => _uncommitedEvent.Clear();

    public abstract void Apply(DomainEvent @event);

    public void ApplyAndPublish(DomainEvent @event)
    {
        _uncommitedEvent.Add(@event);
        this.Apply(@event);
    }
}