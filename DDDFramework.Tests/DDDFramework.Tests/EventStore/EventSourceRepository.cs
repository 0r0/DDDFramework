using Aggregate;

namespace DDDFramework.Tests.EventStore;

/// <summary>
/// load aggregate form repository of events
/// </summary>
public class EventSourceRepository<T, TKey> : IEventSourceRepository<T, TKey> where T : AggregateRoot<TKey>
{
    private readonly IEventStore _eventStore;
    private readonly IAggregateRootFactory _aggregateRootFactory;

    /// <summary>
    /// event store send events as parameter to aggregateRootFactory then it return aggregate root for us
    /// </summary>
    /// <param name="eventStore"></param>
    /// <param name="aggregateRootFactory"></param>
    public EventSourceRepository(IEventStore eventStore, IAggregateRootFactory aggregateRootFactory)
    {
        _eventStore = eventStore;
        _aggregateRootFactory = aggregateRootFactory;
    }

    /// <summary>
    /// get events from event store and save it in events variable
    /// send send events as parameter to create method of aggregate root factory
    /// return created aggregate root
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public T GetById(TKey id)
    {
        var eventsList = _eventStore.GetEvents(GetStreamId(id));
        return _aggregateRootFactory.Create<T>(eventsList);
    }

    private string GetStreamId(TKey id)
    {
        return $"{typeof(T).Name}-{id}";
    }
}