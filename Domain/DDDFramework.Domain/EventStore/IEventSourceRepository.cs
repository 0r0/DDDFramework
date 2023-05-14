using Aggregate;

namespace DDDFramework.Domain.EventStore;

public interface IEventSourceRepository<T, TKey> : IRepository where T : AggregateRoot<TKey>
{
   T GetById(TKey id);
    void AppendEvents(T aggregate);
}