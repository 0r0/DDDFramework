using Newtonsoft.Json.Linq;

namespace DDDFramework.Core.Filter;

public class GreaterThanOperation : IOperation
{
    private readonly string _key;

    public GreaterThanOperation(string key)
    {
        _key = key;
    }

    public JObject Apply(JObject jObject)
    {
        jObject[_key] = 100;
        return jObject;
    }
}