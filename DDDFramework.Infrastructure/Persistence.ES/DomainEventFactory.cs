using Aggregate;
using EventStore.Client;
using Newtonsoft.Json;

namespace Persistence.ES;

internal static class DomainEventFactory
{
    public static IReadOnlyCollection<DomainEvent> Create(IReadOnlyCollection<ResolvedEvent> resolvedEvents,
        IEventTypeResolver resolver)
    {
        return resolvedEvents.Select(a => Create(a, resolver)).ToList();
    }

    public static DomainEvent Create(ResolvedEvent resolvedEvent, IEventTypeResolver resolver)
    {
        var type = resolver.GetType(resolvedEvent.Event.EventType);
        var body = resolvedEvent.Event.Data.ToString();
        return JsonConvert.DeserializeObject<DomainEvent>(body)  ?? throw new InvalidOperationException();
    }
}