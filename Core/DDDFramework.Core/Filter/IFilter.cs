using Newtonsoft.Json.Linq;

namespace DDDFramework.Core.Filter;

public interface IFilter
{
    JObject Apply(JObject jObject);
    void SetFilter(IFilter filter);
}