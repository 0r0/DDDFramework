namespace Persistence.ES.Mapping.Filter;

public class MappingErrorException : Exception
{
    public MappingErrorException(string? message) : base(message)
    {
    }
}