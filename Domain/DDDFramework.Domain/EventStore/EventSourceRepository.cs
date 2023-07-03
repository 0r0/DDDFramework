using Aggregate;

namespace DDDFramework.Domain.EventStore;

/// <summary>
/// load aggregate form repository of events
/// </summary>
public class EventSourceRepository<T, TKey> : IEventSourceRepository<T, TKey> where T : AggregateRoot<TKey>
{
    private readonly IEventStore _eventStore;
    private readonly IAggregateRootFactory _aggregateRootFactory;


    public EventSourceRepository(IEventStore eventStore, IAggregateRootFactory aggregateRootFactory)
    {
        _eventStore = eventStore;
        _aggregateRootFactory = aggregateRootFactory;
    }


    public T GetById(TKey id)
    {
        var eventsList = _eventStore.GetEvents(GetStreamId(id));
        return _aggregateRootFactory.Create<T>(eventsList.Result);
    }

    public void AppendEvents(T aggregate)
    {
        var events = aggregate.GetUncommittedEvents();
        _eventStore.Append(GetStreamId(aggregate.Id), events);
    }

    private string GetStreamId(TKey id)
    {
        return $"{typeof(T).Name}-{id}";
    }
}