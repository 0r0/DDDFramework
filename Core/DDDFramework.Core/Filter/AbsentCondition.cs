using Newtonsoft.Json.Linq;

namespace DDDFramework.Core.Filter;

public class AbsentCondition : ICondition
{
    public string PropertyName { get; }

    public AbsentCondition(string propertyName)
    {
        PropertyName = propertyName;
    }


    public bool IsSatisfied(JObject jObject)
    {
        return jObject[PropertyName] is null;
    }
}