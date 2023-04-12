using System.Reflection;
using Gateways.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace DDDFramework.Application;

public  static class ServiceCollectionExtensions
{
    
    public static void AddControllersInGateways(this IServiceCollection serviceCollection)
    {
        var assembly = Assembly.GetAssembly(typeof(ControllerBase));
        if(assembly is not null)
        {
            serviceCollection.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(assembly));
        }
        else
        {
            serviceCollection.AddControllers();
        }
    }
}