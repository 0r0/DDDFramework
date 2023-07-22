using Newtonsoft.Json.Linq;

namespace DDDFramework.Core.Filter;

public class GreaterThanCondition : ICondition
{
    public string PropertyName { get; }
    private readonly long _greaterThan;

    public GreaterThanCondition(string propertyName, long greaterThan)
    {
        PropertyName = propertyName;
        _greaterThan = greaterThan;
    }


    public bool IsSatisfied(JObject jObject)
    {
        return (jObject[PropertyName] ?? throw new InvalidOperationException()).Value<long>() > _greaterThan;
    }
}