using Newtonsoft.Json.Linq;

namespace Persistence.ES.Mapping.Filter;

public interface IOperation
{
    JObject Apply(JObject jObject);
}