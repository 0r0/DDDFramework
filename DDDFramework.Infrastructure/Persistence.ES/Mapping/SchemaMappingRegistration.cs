using System.Reflection;
using Persistence.ES.Mapping.Filter;

namespace Persistence.ES.Mapping;

public static class SchemaMappingRegistration
{
    private static Dictionary<Type, IFilter> _filters = new Dictionary<Type, IFilter>();

    public static void RegisterMappingsInAssembly(Assembly assembly)
    {
        var mapping = assembly.GetTypes().Where(a => a.BaseType == typeof(SchemaMapping<>))
            .Select(Activator.CreateInstance).OfType<ISchemaMapping>()
            .ToDictionary(a => a.GetType().GetGenericTypeDefinition(), a => a.CreateFilter());
    }


    public static IFilter? GetFilterByType(Type type)
    {
        return _filters.ContainsKey(type) ? _filters[type] : null;
    }
}