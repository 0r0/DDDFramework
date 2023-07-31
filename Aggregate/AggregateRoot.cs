namespace Aggregate;

public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
{
    public readonly List<DomainEvent> _uncommittedEvent;

    public long Version { get; private set; }

    protected AggregateRoot()
    {
        _uncommittedEvent = new List<DomainEvent>();
    }

    public IReadOnlyList<DomainEvent> GetUncommittedEvents() => _uncommittedEvent.AsReadOnly();


    public void AddEvent(DomainEvent @event)

    {
        if (@event is null) throw new ArgumentNullException($"domain event can  not be null=>{nameof(@event)}");
        _uncommittedEvent.Add(@event);
    }

    public virtual void RemoveEvent(DomainEvent @event)
    {
        if (@event is null) throw new ArgumentNullException($"domain event can  not be null=>{nameof(@event)}");

        _uncommittedEvent.Remove(@event);
    }

    public void UpdateVersion() => ++Version;

    public void SetAggregateVersion() => ++Version;
    public void SetDomainEventVersion(DomainEvent @event) => @event.Version = Version + 1L;
    public void ClearUncommittedEvent() => _uncommittedEvent.Clear();

    public abstract void Apply(DomainEvent @event);

    public void ApplyAndPublish(DomainEvent @event)
    {
        _uncommittedEvent.Add(@event);
        Apply(@event);
    }
}