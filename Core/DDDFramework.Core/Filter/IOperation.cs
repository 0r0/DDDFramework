using Newtonsoft.Json.Linq;

namespace DDDFramework.Core.Filter;

public interface IOperation
{
    JObject Apply(JObject jObject);
}