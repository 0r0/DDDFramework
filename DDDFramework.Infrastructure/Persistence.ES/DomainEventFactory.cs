using System.Text;
using Aggregate;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace Persistence.ES;

internal static class DomainEventFactory
{
    public static IReadOnlyCollection<DomainEvent> Create(IReadOnlyCollection<ResolvedEvent> resolvedEvents)
    {
        return resolvedEvents.Select(Create).ToList();
    }

    public static DomainEvent Create(ResolvedEvent resolvedEvent)
    {
        var type = resolvedEvent.Event.EventType;
        var body = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
        return JsonConvert.DeserializeObject(body) as DomainEvent ?? throw new InvalidOperationException();
    }
}