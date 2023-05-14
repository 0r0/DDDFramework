﻿using Aggregate;

namespace DDDFramework.Domain.EventStore;

/// <summary>
/// get events from event store by sending event stream Id to event store;
/// </summary>
public interface IEventStore
{
    IReadOnlyCollection<DomainEvent> GetEvents(string eventStreamId);
    void Append(string streamName, IReadOnlyCollection<DomainEvent> events);
}