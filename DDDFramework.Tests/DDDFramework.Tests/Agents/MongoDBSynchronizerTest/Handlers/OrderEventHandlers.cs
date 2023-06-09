﻿using DDDFramework.Core.Application.Contracts;
using DDDFramework.Domain.Contracts.Order;

namespace DDDFramework.Tests.Agents.MongoDBSynchronizerTest.Handlers;

public class OrderEventHandlers : IEventHandler<OrderCreated>

{
    public async Task Handle(OrderCreated @event)
    {
        await Task.CompletedTask;
    }
}