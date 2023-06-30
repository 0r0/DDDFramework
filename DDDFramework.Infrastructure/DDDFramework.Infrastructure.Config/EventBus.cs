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

    public async Task Publish<T>(T @event) where T : DomainEvent
    {
        var handler = _lifetimeScope.Resolve<IEventHandler<T>>() ?? throw new Exception("Hi life time scope has exception");
        await handler.Handle(@event);
    }
}