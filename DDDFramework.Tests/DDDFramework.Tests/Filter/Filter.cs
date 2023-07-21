using Newtonsoft.Json.Linq;

namespace DDDFramework.Tests.Filter;

public class Filter : IFilter
{
    private readonly ICondition _condition;
    private readonly IOperation _operation;
    private  IFilter? _nextFilter;

    public Filter(ICondition condition, IOperation operation)
    {
        _condition = condition;
        _operation = operation;
    }

    public void SetFilter(IFilter filter)
    {
        _nextFilter = filter;
    }

    public JObject Apply(JObject jObject)
    {
        if (_condition.IsSatisfied(jObject: jObject))
            _operation.Apply(jObject: jObject);
        
        return _nextFilter is null ? jObject : _nextFilter.Apply(jObject);
    }
}