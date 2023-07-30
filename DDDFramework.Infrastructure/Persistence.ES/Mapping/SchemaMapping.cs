using Aggregate;
using Persistence.ES.Mapping.BuilderFactory;
using Persistence.ES.Mapping.Filter;

namespace Persistence.ES.Mapping;

public abstract class SchemaMapping<T> : ISchemaMapping where T : DomainEvent
{
    public IFilter CreateFilter()
    {
        var builder = CreateFilterBuilder();
        Configure(builder);
        return builder.Build();
    }

    protected abstract void Configure(IFilterBuilder builder);


    private FilterBuilder CreateFilterBuilder()
    {
        return new FilterBuilder();
    }
}