using Newtonsoft.Json.Linq;

namespace Persistence.ES.Mapping.Filter;

public interface IFilter
{
    JObject Apply(JObject jObject);
    void SetFilter(IFilter filter);
}