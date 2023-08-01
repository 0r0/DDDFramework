using Newtonsoft.Json.Linq;

namespace Persistence.ES.Mapping.Filter;

public class NullFilter :IFilter
{
    public JObject Apply(JObject jObject)
    {
        return jObject;
    }

    public void SetFilter(IFilter filter)
    {
    }

    public static IFilter Instance =>  new NullFilter();
}