using Newtonsoft.Json.Linq;

namespace DDDFramework.Core.Filter;

public interface ICondition
{
    bool IsSatisfied(JObject jObject);
}