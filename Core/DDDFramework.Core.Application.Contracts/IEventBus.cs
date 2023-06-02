using Aggregate;

namespace DDDFramework.Core.Application.Contracts;

public interface IEventBus
{
    Task Publish<T>(T @event) where T : DomainEvent;

}