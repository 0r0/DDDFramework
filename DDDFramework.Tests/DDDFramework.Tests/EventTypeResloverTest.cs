using DDDFramework.Domain.Contracts.Order;
using Persistence.ES;

namespace DDDFramework.Tests;


public class EventTypeResolverTest
{
    [Fact] public void add_and_get_domain_events_from_assemblies()
    {
        var resolver = new EventTypeResolver();
        resolver.AddTypesFromAssemblies(typeof(OrderCreated).Assembly);
        Assert.Equal(typeof(OrderCreated),resolver.GetType(nameof(OrderCreated)));
    }
}