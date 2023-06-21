using System.Text;
using Aggregate;
using EventStore.Client;
using Newtonsoft.Json;
using EventData = EventStore.Client.EventData;

namespace Persistence.ES;

internal static class EventDataFactory
{
    public static EventData CreateFromDomainEvent(DomainEvent domainEvent)
    {
        var evt = new
        {
            a = 2
        };
        var data = JsonConvert.SerializeObject(domainEvent);

        var eventData = new EventData(
            Uuid.NewUuid(),
            "TestEvent",
            Encoding.UTF8.GetBytes(data)
        );
        // return new EventData(eventId: domainEvent.EventId,
        //     type: domainEvent.GetType().Name,
        //     isJson: true,
        //     data: Encoding.UTF8.GetBytes(data),
        //     metadata: Array.Empty<byte>()
        // );
        return default;
    }

    public static IList<EventData> CreateFromDomainEvents(IReadOnlyCollection<DomainEvent> domainEvents)
    {
        return domainEvents.Select(CreateFromDomainEvent).ToList();
    }
}