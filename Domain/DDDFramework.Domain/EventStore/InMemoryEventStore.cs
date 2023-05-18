using Aggregate;

namespace DDDFramework.Domain.EventStore;

public class InMemoryEventStore : IEventStore
{
    private readonly Dictionary<string, IReadOnlyCollection<DomainEvent>> _events = new();

    public Task<IReadOnlyCollection<DomainEvent>> GetEvents(string eventStreamId)
    {
        return  Task.FromResult(_events[eventStreamId]);
    }

    public Task Append(string streamName, IReadOnlyCollection<DomainEvent> events)
    {
        if (_events.TryGetValue(streamName, out var @event))
            @event.ToList().AddRange(events);
        _events.Add(streamName, events);
        return Task.CompletedTask;
    }
}