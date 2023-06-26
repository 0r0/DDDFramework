using System.Reflection;
using Aggregate;

namespace Persistence.ES;

public class EventTypeResolver : IEventTypeResolver
{
    private readonly Dictionary<string, Type> _types = new();

    public void AddTypesFromAssemblies(Assembly assembly)
    {
        assembly.GetTypes().Where(a => a.IsSubclassOf(typeof(DomainEvent))).ToList()
            .ForEach(a => _types.Add(a.Name, a));
    }

    public Type GetType(string typeName)
    {
        if (string.IsNullOrEmpty(typeName))
            throw new ArgumentNullException(typeName, "typeName can not be null");
        return _types.ContainsKey(typeName) ? _types[typeName] : null;
    }
}