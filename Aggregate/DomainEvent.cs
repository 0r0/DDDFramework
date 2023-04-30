namespace Aggregate;

public class DomainEvent : IDomainEvent
{
    public Guid EventId => Guid.NewGuid();

    public long Version { get; set; } = 1;


    public DateTime PublishTime => DateTime.Now;
}