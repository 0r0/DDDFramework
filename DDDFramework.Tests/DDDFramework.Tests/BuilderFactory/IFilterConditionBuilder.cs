using DDDFramework.Core.Filter;

namespace DDDFramework.Tests.BuilderFactory;

public interface IFilterConditionBuilder
{
    
    IFilterOperationBuilder WhenAbsent(string key);
    IFilterOperationBuilder WhenGreaterThan(string key,long greaterThanValue);

    IFilter Build();

}