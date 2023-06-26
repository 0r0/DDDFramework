using Aggregate;

namespace DDDFramework.Core.Application.Contracts;

public interface IEventHandler<in T> where T :DomainEvent
{
    Task Handle(T @event);
}