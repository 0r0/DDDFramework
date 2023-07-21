using Newtonsoft.Json.Linq;

namespace DDDFramework.Core.Filter;

public interface ICondition
{
    string PropertyName { get; }
    bool IsSatisfied(JObject jObject);
}