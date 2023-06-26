using System.Reflection;

namespace Persistence.ES;

public interface IEventTypeResolver
{
    public void AddTypesFromAssemblies(Assembly assembly);
    public Type GetType(string typeName);
}