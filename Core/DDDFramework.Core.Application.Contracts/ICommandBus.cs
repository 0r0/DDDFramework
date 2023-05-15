namespace DDDFramework.Core.Application.Contracts;

public interface ICommandBus
{
    public void Dispatch<T>(T command);
}