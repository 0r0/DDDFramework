using Aggregate;

namespace DDDFramework.Tests.EventStore;

public interface IEventStore
{
    IReadOnlyCollection<DomainEvent> GetEvents(string eventStreamId);
}