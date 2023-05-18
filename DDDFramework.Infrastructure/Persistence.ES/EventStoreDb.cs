using Aggregate;
using DDDFramework.Domain.EventStore;
using EventStore.ClientAPI;

namespace Persistence.ES;

public class EventStoreDb : IEventStore
{
    private readonly IEventStoreConnection _connection;

    public EventStoreDb(IEventStoreConnection connection)
    {
        _connection = connection;
    }

    public async Task<IReadOnlyCollection<DomainEvent>> GetEvents(string eventStreamId)
    {
        var streamEvents = await EventStreamReader.
            Read(_connection, eventStreamId, StreamPosition.Start, 200);

        return DomainEventFactory.Create(streamEvents);
    }

    public async Task Append(string streamName, IReadOnlyCollection<DomainEvent> events)
    {
        var eventsData = EventDataFactory.CreateFromDomainEvents(events);
        await _connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventsData);
    }
}