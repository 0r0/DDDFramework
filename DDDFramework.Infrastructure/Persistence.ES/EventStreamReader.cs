using EventStore.Client;

namespace Persistence.ES;

public static class EventStreamReader
{
    public static async Task<List<ResolvedEvent>> Read(EventStoreClient eventStoreClient, string streamId,
        StreamPosition start, int end)
    {
        var result = eventStoreClient.ReadStreamAsync(Direction.Forwards, streamId,
            start, 200);

        return await result.ToListAsync();
    }
}