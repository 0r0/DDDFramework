namespace DDDFramework.Core.Filter;

public class MappingErrorException : Exception
{
    public MappingErrorException(string? message) : base(message)
    {
    }
}