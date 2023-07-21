﻿using Newtonsoft.Json.Linq;

namespace DDDFramework.Core.Filter;

public class NullFilter :IFilter
{
    private static IFilter? _instance;
    public JObject Apply(JObject jObject)
    {
        return jObject;
    }

    public static IFilter Instance => _instance ?? new NullFilter();
}