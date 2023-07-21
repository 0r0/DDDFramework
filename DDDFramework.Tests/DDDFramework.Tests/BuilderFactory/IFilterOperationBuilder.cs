namespace DDDFramework.Tests.BuilderFactory;

public interface IFilterOperationBuilder
{
    IFilterConditionBuilder DefaultValue(string key,string value);
    IFilterConditionBuilder AnotherProperty(string key, string anotherValue);
    IFilterConditionBuilder GreaterThan(string key);
    IFilterConditionBuilder ErrorOperation(string message);
}