using Aggregate;

namespace DDDFramework.Tests.Agents.MongoDBSynchronizerTest;

public interface IEventHandler
{
   public void Handle<T>(T @event) where T : DomainEvent;
}