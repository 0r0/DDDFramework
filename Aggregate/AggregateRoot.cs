namespace Aggregate;

public class AggregateRoot<T> : IAggregateRoot<T> 
{
    public Id<T> Id { get; set; }
}