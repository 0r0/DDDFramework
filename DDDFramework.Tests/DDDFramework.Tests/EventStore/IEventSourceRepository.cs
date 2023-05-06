using Aggregate;

namespace DDDFramework.Tests.EventStore;

public interface IEventSourceRepository<T, TKey> : IRepository where T : AggregateRoot<TKey> 
{
    T GetById(TKey id);
}