using Aggregate;
using Autofac;
using DDDFramework.Core.Application.Contracts;

namespace DDDFramework.Infrastructure.Config;

public class EventBus :IEventBus

{
    private readonly ILifetimeScope _lifetimeScope;

    public EventBus(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
       
    }

    public async Task Publish<T>(T @event) where T : IEvent
    {
        using var scope = _lifetimeScope.BeginLifetimeScope();
        var handler = scope.Resolve<IEventHandler<T>>();
        await handler.Handle(@event);
    }
}