using Newtonsoft.Json.Linq;

namespace DDDFramework.Tests.Filter;

public interface ICondition
{
    bool IsSatisfied(JObject jObject);
}