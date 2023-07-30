using Aggregate;

namespace DDDFramework.Core.Application.Contracts;

public interface IEventHandler<in T> where T :IEvent
{
    Task Handle(T @event);
}