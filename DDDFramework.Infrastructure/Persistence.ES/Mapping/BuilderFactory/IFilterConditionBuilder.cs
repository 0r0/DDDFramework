namespace Persistence.ES.Mapping.BuilderFactory;

public interface IFilterConditionBuilder
{
    
    IFilterOperationBuilder WhenAbsent(string key);
    IFilterOperationBuilder WhenGreaterThan(string key,long greaterThanValue);

    // IFilter Build();

}

public interface IFilterBuilder : IFilterConditionBuilder
{
    
}