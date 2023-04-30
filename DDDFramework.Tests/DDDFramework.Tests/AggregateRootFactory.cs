using Aggregate;

namespace DDDFramework.Tests;

public class AggregateRootFactory : IAggregateRootFactory
{
    public T Create<T>(IReadOnlyCollection<DomainEvent> events) where T : IAggregateRoot
    {
      //call all events then create aggregate root and return it
      var aggregate = Activator.CreateInstance<T>();
      foreach (var @event in events)
      {
          aggregate.Apply(@event);
      }

      return aggregate;

    }
}