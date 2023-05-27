using Aggregate;
using DDDFramework.Domain.EventStore;
using EventStore.ClientAPI;

namespace Persistence.ES;

public class EventStoreDb : IEventStore
{
    private readonly IEventStoreConnection _connection;
    private readonly IEventTypeResolver _eventTypeResolver;
    public EventStoreDb(IEventStoreConnection connection, IEventTypeResolver eventTypeResolver)
    {
        _connection = connection;
        _eventTypeResolver = eventTypeResolver;
    }

    public async Task<IReadOnlyCollection<DomainEvent>> GetEvents(string eventStreamId)
    {
        var streamEvents = await EventStreamReader.
            Read(_connection, eventStreamId, StreamPosition.Start, 200);

        return DomainEventFactory.Create(streamEvents,_eventTypeResolver);
    }

    public async Task Append(string streamName, IReadOnlyCollection<DomainEvent> events)
    {
        var eventsData = EventDataFactory.CreateFromDomainEvents(events);
        await _connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventsData);
    }
}