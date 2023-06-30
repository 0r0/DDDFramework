using Autofac;
using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Infrastructure.Config;
using DDDFramework.Tests.IOCModules;

namespace DDDFramework.Tests.Agents.MongoDBSynchronizerTest;

public class EventHandlerTest
{
    [Fact]
    public async Task Dispatch_EventHandler_Successfully()
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule<OrderTestModule>();

        await using var requestScope = builder.Build().BeginLifetimeScope();
        var eventBus = new EventBus(requestScope);
        var orderCreated = new OrderCreated(new OrderId(Guid.NewGuid()),
            10, "Hi", false);

        Assert.True(eventBus.Publish(orderCreated).IsCompleted);
    }

    [Fact]
    public async Task Dispatch_EventHandler_with_argument_null_exception_when_scope_is_not_defined()
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule<OrderTestModule>();

        await using var requestScope = builder.Build().BeginLifetimeScope();
        var eventBus = new EventBus(default);
        var orderCreated = new OrderCreated(new OrderId(Guid.NewGuid()),
            10, "Hi", false);
        await Assert.ThrowsAsync<ArgumentNullException>(() => eventBus.Publish(orderCreated));
    }
}