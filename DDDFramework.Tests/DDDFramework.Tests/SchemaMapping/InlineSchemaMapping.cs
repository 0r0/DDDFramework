using Aggregate;
using DDDFramework.Domain.Contracts.Order;
using Persistence.ES.Mapping;
using Persistence.ES.Mapping.BuilderFactory;

namespace DDDFramework.Tests.SchemaMapping;

public class InlineSchemaMapping<T> :SchemaMapping<T> where T : DomainEvent
{
    private readonly Action<IFilterBuilder> _configuration;

    public InlineSchemaMapping(Action<IFilterBuilder> configuration)
    {
        _configuration = configuration;
    }
    protected override void Configure(IFilterBuilder builder)
    {
        _configuration.Invoke(builder);
    }
}