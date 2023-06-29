using Aggregate;

namespace DDDFramework.Tests.Agents.MongoDBSynchronizerTest;

public class EventHandler :IEventHandler
{
    public void Handle<T>(T @event) where T : DomainEvent
    {
        throw new NotImplementedException();
    }
}