﻿using Persistence.ES.Mapping.Filter;

namespace Persistence.ES.Mapping.BuilderFactory;

public class FilterBuilder : IFilterBuilder, IFilterOperationBuilder
{
    private ICondition _currentCondition;

    public string PropertyName { get; set; }
    private readonly List<IFilter> Filters = new List<IFilter>();
    public FilterBuilder()
    {
       
    }



    public IFilterOperationBuilder WhenAbsent(string key)
    {
        PropertyName = key;
        _currentCondition = new AbsentCondition(key);
        return this;
    }

    public IFilterOperationBuilder WhenGreaterThan(string key, long greaterThanValue)
    {
        _currentCondition = new GreaterThanCondition(key, greaterThanValue);
        return this;
    }

    public IFilterConditionBuilder DefaultValue(string key, string value)
    {
        var operation = new DefaultValueOperation(key, value);
        return AddFilter(operation);
    }


    public IFilterConditionBuilder AnotherProperty(string key, string anotherValue)
    {
        var operation = new AnotherPropertyOperation(key, anotherValue);
        return AddFilter(operation);
    }

    public IFilterConditionBuilder GreaterThan(string key)
    {
        var operation = new GreaterThanOperation(key);
        return AddFilter(operation);
    }

    public IFilterConditionBuilder ErrorOperation(string message)
    {
        var operation = new ErrorOperation(message);
        return AddFilter(operation);
    }

    private IFilterConditionBuilder AddFilter(IOperation operation)
    {
        Filters.Add(new Filter.Filter(_currentCondition, operation));
        return this;
    }


    public IFilter Build()
    {
        for (var i = Filters.Count - 1; i > 0; i--)
        {
            Filters[i].SetFilter(Filters[i - 1]);
        }

        return Filters.Last();
    }
}