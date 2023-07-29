using Persistence.ES.Mapping.Filter;

namespace Persistence.ES.Mapping;

public interface ISchemaMapping
{
    public IFilter CreateFilter();
}