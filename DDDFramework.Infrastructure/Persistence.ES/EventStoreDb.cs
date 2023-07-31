using Aggregate;
using DDDFramework.Domain.EventStore;
using EventStore.Client;

namespace Persistence.ES;

public class EventStoreDb : IEventStore
{
    private readonly EventStoreClient _client;
    private readonly IEventTypeResolver _eventTypeResolver;

    public EventStoreDb(EventStoreClient client, IEventTypeResolver eventTypeResolver)
    {
        _client = client;
        _eventTypeResolver = eventTypeResolver;
    }

    public async Task<IReadOnlyCollection<DomainEvent>> GetEvents(string eventStreamId)
    {
        var streamEvents = await EventStreamReader.Read(_client, eventStreamId, StreamPosition.Start, 200);

        return DomainEventFactory.Create(streamEvents, _eventTypeResolver);
    }

    public async Task Append(string streamName, IReadOnlyCollection<DomainEvent> events)
    {
        var eventsData = EventDataFactory.CreateFromDomainEvents(events);

        foreach (var eventData in eventsData)
        {
            await _client.AppendToStreamAsync(streamName, StreamState.Any, new[] {eventData});
        }
    }
}