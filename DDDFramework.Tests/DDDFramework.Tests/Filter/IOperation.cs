using Newtonsoft.Json.Linq;

namespace DDDFramework.Tests.Filter;

public interface IOperation
{
    JObject Apply(JObject jObject);
}