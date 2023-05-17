using Aggregate;

namespace DDDFramework.Domain.EventStore;

public class InMemoryEventStore : IEventStore
{
    private readonly Dictionary<string, IReadOnlyCollection<DomainEvent>> _events = new();

    public IReadOnlyCollection<DomainEvent> GetEvents(string eventStreamId)
    {
        return _events[eventStreamId];
    }

    public void Append(string streamName, IReadOnlyCollection<DomainEvent> events)
    {
        if (_events.ContainsKey(streamName))
            _events[streamName].ToList().AddRange(events);
        _events.Add(streamName, events);
    }
}