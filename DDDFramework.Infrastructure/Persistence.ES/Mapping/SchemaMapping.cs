using Aggregate;
using Persistence.ES.Mapping.BuilderFactory;
using Persistence.ES.Mapping.Filter;

namespace Persistence.ES.Mapping;

public abstract class SchemaMapping<T> where T : DomainEvent
{
    public IFilter CreateFilter()
    {
        var builder = CreateFilterBuilder();
        Configure(builder);
        return builder.Build();
    }

    protected abstract void Configure(IFilterBuilder builder);
    // {
    //     builder.WhenAbsent("name").AnotherProperty("name", "fullName")
    //         .WhenAbsent("description").DefaultValue("description", "default description");
    // }

    private FilterBuilder CreateFilterBuilder()
    {
        return new FilterBuilder();
    }
}