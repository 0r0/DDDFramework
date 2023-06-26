using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using ServiceHost.Conventions;

namespace ServiceHost;

public static class ServiceCollectionExtensions
{
    public static void AddControllersInGateways(this IServiceCollection serviceCollection)
    {
        var assembly = Assembly.GetAssembly(typeof(ControllerBase));
        if(assembly is not null)
        {
            serviceCollection.AddControllers(a=>a.Conventions.Add(new QueryControllerModelConvention())).PartManager.ApplicationParts.Add(new AssemblyPart(assembly));
        }
        else
        {
            serviceCollection.AddControllers(a=>a.Conventions.Add(new QueryControllerModelConvention()));
        }
    }
}