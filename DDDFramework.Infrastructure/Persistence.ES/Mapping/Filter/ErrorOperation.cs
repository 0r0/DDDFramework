using Newtonsoft.Json.Linq;

namespace Persistence.ES.Mapping.Filter;

public class ErrorOperation : IOperation
{
    private readonly string _errorMessage;

    public ErrorOperation(string errorMessage)
    {
        _errorMessage = errorMessage;
    }

    public JObject Apply(JObject jObject)
    {
        throw new MappingErrorException(_errorMessage);
    }
}