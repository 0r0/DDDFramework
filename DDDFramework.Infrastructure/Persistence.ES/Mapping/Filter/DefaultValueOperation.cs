﻿using Newtonsoft.Json.Linq;

namespace Persistence.ES.Mapping.Filter;

public class DefaultValueOperation :IOperation
{
    private readonly string _key;
    private readonly string _value;

    public DefaultValueOperation(string key, string value)
    {
        _key = key;
        _value = value;
    }

    public JObject Apply(JObject jObject)
    {
        jObject[_key] = _value;
        return jObject;
    }
}