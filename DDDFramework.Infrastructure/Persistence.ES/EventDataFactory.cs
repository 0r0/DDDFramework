using System.Text;
using Aggregate;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace Persistence.ES;

internal static class EventDataFactory
{
    public static EventData CreateFromDomainEvent(DomainEvent domainEvent)
    {
        var data = JsonConvert.SerializeObject(domainEvent);
        return new EventData(eventId: domainEvent.EventId,
            type: domainEvent.GetType().Name,
            isJson: true,
            data: Encoding.UTF8.GetBytes(data),
            metadata: Array.Empty<byte>()
        );
    }

    public static IReadOnlyCollection<EventData> CreateFromDomainEvents(IReadOnlyCollection<DomainEvent> domainEvents)
    {
        return domainEvents.Select(CreateFromDomainEvent).ToList();
    }
}