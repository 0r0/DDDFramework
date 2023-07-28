using Newtonsoft.Json.Linq;

namespace Persistence.ES.Mapping.Filter;

public class NullFilter :IFilter
{
    private static IFilter? _instance;
    public JObject Apply(JObject jObject)
    {
        return jObject;
    }

    public void SetFilter(IFilter filter)
    {
    }

    public static IFilter Instance => _instance ?? new NullFilter();
}