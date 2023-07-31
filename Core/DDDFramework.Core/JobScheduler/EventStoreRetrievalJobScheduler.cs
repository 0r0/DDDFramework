using DDDFramework.Core.Application.Contracts;
using DDDFramework.Core.CursorManager;
using EventStore.Client;
using Microsoft.Extensions.Options;
using Quartz;

namespace DDDFramework.Core.JobScheduler;

[DisallowConcurrentExecution]
public class EventStoreRetrievalJobScheduler : IJob
{
    private readonly EventStoreClient _client;
    private readonly IEventBus _eventBus;
    private readonly ICursor _cursor;
    private readonly EventStoreOptions _options;

    public EventStoreRetrievalJobScheduler(EventStoreClient client, IEventBus eventBus, ICursor cursor,
        IOptions<EventStoreOptions> options)
    {
        _client = client;
        _eventBus = eventBus;
        _cursor = cursor;
        _options = options.Value;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var cursorPosition = _cursor.CurrentCursor();
        // var @events = await _client.SubscribeToStreamAsync();
        //foreach events and dispatch in event Bus;
    }
}