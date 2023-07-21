using DDDFramework.Core.Filter;
using Newtonsoft.Json.Linq;

namespace DDDFramework.Tests.BuilderFactory;

public class AbsentCondition : ICondition
{
    private readonly string _key;

    public AbsentCondition(string key)
    {
        _key = key;
    }

    public bool IsSatisfied(JObject jObject)
    {
        return jObject[_key] is  null; 
    }
}