using Aggregate;
using MassTransit;

namespace DDDFramework.Tests;

public class AggregateRootImplementation : AggregateRoot<Guid>
{
    public override void Apply(DomainEvent @event)
    {
        throw new NotImplementedException();
    }
    
    
}
