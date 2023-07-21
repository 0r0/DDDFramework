using Newtonsoft.Json.Linq;

namespace DDDFramework.Core.Filter;

public class AnotherPropertyOperation : IOperation
{
    private readonly string _key;
    private readonly string _anotherValue;

    public AnotherPropertyOperation(string key, string anotherValue)
    {
        _key = key;
        _anotherValue = anotherValue;
    }

    public JObject Apply(JObject jObject)
    {
        jObject[_key] ??= jObject[_anotherValue];
        jObject.Remove(_anotherValue);
        return jObject;
    }
}