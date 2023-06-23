using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ServiceHost.Conventions;

public class QueryControllerModelConvention : IApplicationModelConvention
{
    private const string ModelNameString = "Query";

    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers.Where(a => a.ControllerName.EndsWith(ModelNameString)))
        {
            foreach (var selectorModel in controller.Selectors.Where(selector => selector.AttributeRouteModel != null))
            {
                selectorModel.AttributeRouteModel = new AttributeRouteModel()
                {
                    Template = "api/" + controller.ControllerName.Replace(ModelNameString, "")
                };
            }
        }
    }
}