using EventStore.Client;

namespace Aggregate;

public abstract class DomainEvent : IDomainEvent
{
    public Uuid EventId => Uuid.NewUuid();

    public long Version { get; set; } = 1;


    public DateTime PublishTime => DateTime.Now;
}