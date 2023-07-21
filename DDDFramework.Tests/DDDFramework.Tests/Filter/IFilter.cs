using Newtonsoft.Json.Linq;

namespace DDDFramework.Tests.Filter;

public interface IFilter
{
    JObject Apply(JObject jObject);
}