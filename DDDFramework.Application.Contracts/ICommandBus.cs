namespace DDDFramework.Application.Contracts;

public interface ICommandBus
{
    public void Dispatch<T>(T command);
}