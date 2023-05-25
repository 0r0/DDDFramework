using System.Text;
using Aggregate;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace Persistence.ES;

internal static class DomainEventFactory
{
    public static IReadOnlyCollection<DomainEvent> Create(IReadOnlyCollection<ResolvedEvent> resolvedEvents,IEventTypeResolver resolver)
    {
        return resolvedEvents.Select(a=>Create(a,resolver)).ToList();
    }

    public static DomainEvent Create(ResolvedEvent resolvedEvent,IEventTypeResolver resolver)
    {
        
        var type = resolver.GetType(resolvedEvent.Event.EventType);
        var body = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
        return JsonConvert.DeserializeObject<DomainEvent>(body) as DomainEvent ?? throw new InvalidOperationException();
    }
}