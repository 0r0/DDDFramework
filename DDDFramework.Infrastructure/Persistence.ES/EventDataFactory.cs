using System.Text;
using Aggregate;
using EventStore.Client;
using Newtonsoft.Json;

namespace Persistence.ES;

internal static class EventDataFactory
{
    public static EventData CreateFromDomainEvent(DomainEvent domainEvent)
    {
        var data = JsonConvert.SerializeObject(domainEvent);


        return new EventData(eventId: Uuid.NewUuid(),
            type: domainEvent.GetType().Name,
            data: Encoding.UTF8.GetBytes(data),
            metadata: Array.Empty<byte>()
        );
    }

    public static IList<EventData> CreateFromDomainEvents(IReadOnlyCollection<DomainEvent> domainEvents)
    {
        return domainEvents.Select(CreateFromDomainEvent).ToList();
    }
}