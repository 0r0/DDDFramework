namespace Aggregate;

public interface IEventPublisher
{
    void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    IList<object> GetPublishedEvent();
}