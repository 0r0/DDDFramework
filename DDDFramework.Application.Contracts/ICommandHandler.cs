namespace DDDFramework.Application.Contracts;

public interface ICommandHandler<in T>
{
    Task Handle(T command);
}