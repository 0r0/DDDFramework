namespace Aggregate;

public interface IAggregateRoot
{
    void Apply(DomainEvent @event);
}