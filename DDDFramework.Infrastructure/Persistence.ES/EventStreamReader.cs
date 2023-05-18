﻿using EventStore.ClientAPI;

namespace Persistence.ES;

public  static class EventStreamReader
{
    public static async Task<List<ResolvedEvent>> Read(IEventStoreConnection connection, string streamId, int start,
        int end)
    {
        var streamEvents = new List<ResolvedEvent>();
        StreamEventsSlice currentSlice;
        long nextSliceStart = start;
        do
        {
            currentSlice = await connection.ReadStreamEventsForwardAsync(streamId, nextSliceStart, 200, false);
            nextSliceStart = currentSlice.NextEventNumber;
            streamEvents.AddRange(currentSlice.Events);
        } while (currentSlice.NextEventNumber<=end);

        return streamEvents;
    }
}