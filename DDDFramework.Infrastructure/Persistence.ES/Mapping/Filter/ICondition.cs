using Newtonsoft.Json.Linq;

namespace Persistence.ES.Mapping.Filter;

public interface ICondition
{
    string PropertyName { get; }
    bool IsSatisfied(JObject jObject);
}