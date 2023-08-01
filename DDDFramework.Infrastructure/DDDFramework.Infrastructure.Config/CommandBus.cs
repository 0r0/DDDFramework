using Autofac;
using DDDFramework.Core.Application.Contracts;

namespace DDDFramework.Infrastructure.Config;

public class CommandBus : ICommandBus
{
    private readonly ILifetimeScope _lifetimeScope;

    public CommandBus(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
    }

    public void Dispatch<T>(T command)
    {
        using var scope = _lifetimeScope.BeginLifetimeScope();
        var handler = scope.Resolve<ICommandHandler<T>>();
        handler.Handle(command);
    }
}