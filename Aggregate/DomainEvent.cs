namespace Aggregate;

public class DomainEvent :IDomainEvent
{
    public Guid EventId { get; set; }
    public long Version { get; set; }
    public DateTime PublishTime =>DateTime.Now;
    
    
}