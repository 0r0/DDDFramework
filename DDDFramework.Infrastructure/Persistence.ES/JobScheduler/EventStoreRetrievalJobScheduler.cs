using DDDFramework.Core;
using DDDFramework.Core.Application.Contracts;
using DDDFramework.Core.CursorManager;
using EventStore.Client;
using Microsoft.Extensions.Options;
using Quartz;

namespace Persistence.ES.JobScheduler;

[DisallowConcurrentExecution]
public class EventStoreRetrievalJobScheduler : IJob
{
    private readonly EventStoreClient _client;
    private readonly IEventBus _eventBus;
    private readonly ICursor _cursor;
    private readonly EventStoreOptions _options;
    private readonly IEventTypeResolver _eventTypeResolver;


    public EventStoreRetrievalJobScheduler(EventStoreClient client, IEventBus eventBus, ICursor cursor,
        IOptions<EventStoreOptions> options, IEventTypeResolver eventTypeResolver)
    {
        _client = client;
        _eventBus = eventBus;
        _cursor = cursor;
        _eventTypeResolver = eventTypeResolver;
        _options = options.Value;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        
        var cursorPosition = _cursor.CurrentCursor();
        await _client.SubscribeToAllAsync( FromAll.Start,
            async (subscription, @event, cancellationToken) =>
            {
                Console.WriteLine($"quot;Received event {@event.OriginalEventNumber}@{@event.OriginalStreamId}");
                
                await _eventBus.Publish(DomainEventFactory.Create(@event, _eventTypeResolver));
            });
    }
}