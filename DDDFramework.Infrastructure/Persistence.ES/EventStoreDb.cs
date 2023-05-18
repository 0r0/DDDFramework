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
        var streamEvents = new List<ResolvedEvent>();
        StreamEventsSlice currentSlice;
        long nextSliceStart = StreamPosition.Start;
        do
        {
            currentSlice = await _connection.ReadStreamEventsForwardAsync(eventStreamId, nextSliceStart, 200, false);
            nextSliceStart = currentSlice.NextEventNumber;
            streamEvents.AddRange(currentSlice.Events);
        } while (!currentSlice.IsEndOfStream);

        return DomainEventFactory.Create(streamEvents);
    }

    public async Task Append(string streamName, IReadOnlyCollection<DomainEvent> events)
    {
        var eventsData = EventDataFactory.CreateFromDomainEvents(events);
        await _connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventsData);
    }
}