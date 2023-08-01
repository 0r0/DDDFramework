using System.Text;
using Aggregate;
using EventStore.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Persistence.ES.Mapping;

namespace Persistence.ES;

public static class DomainEventFactory
{
    public static IReadOnlyCollection<DomainEvent> Create(IReadOnlyCollection<ResolvedEvent> resolvedEvents,
        IEventTypeResolver resolver)
    {
        return resolvedEvents.Select(a => Create(a, resolver)).ToList();
    }

    public static DomainEvent Create(ResolvedEvent resolvedEvent, IEventTypeResolver resolver)
    {
        var type = resolver.GetType(resolvedEvent.Event.EventType);
        var b = Encoding.UTF8.GetString(resolvedEvent.OriginalEvent.Data.ToArray());
        var body = ApplyMapping(b, type);
        var domainEvent = JsonConvert.DeserializeObject(body,type) as DomainEvent;
        return  domainEvent ?? throw new InvalidOperationException();
    }

    private static string ApplyMapping(string body, Type type)
    {
        var filter = SchemaMappingRegistration.GetFilterByType(type);
        
        if (filter is null) return body;
        
        var filteredBody = filter.Apply(JObject.Parse(body));
        
        return filteredBody.ToString();
    }
}