using System.Reflection;
using Aggregate;

namespace Persistence.ES;

public class EventTypeResolver : IEventTypeResolver
{
    private readonly Dictionary<string, Type> _types = new();
    public void AddTypesFromAssemblies(Assembly assembly)
    {
         assembly.GetTypes().Where(a => a.IsSubclassOf(typeof(DomainEvent))).ToList().ForEach(a=>_types.Add(a.Name,a));
       

    }

    public Type GetType(string typeName)
    {
        return _types[typeName];
    }
}