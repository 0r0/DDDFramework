using Newtonsoft.Json.Linq;

namespace DDDFramework.Tests.Filter;

public class GreaterThanCondition : ICondition
{
    private readonly string _key;
    private readonly long _greaterThan;

    public GreaterThanCondition(string key, long greaterThan)
    {
        _key = key;
        _greaterThan = greaterThan;
    }

    public bool IsSatisfied(JObject jObject)
    {
        return (jObject[_key] ?? throw new InvalidOperationException()).Value<long>() > _greaterThan;
    }
}