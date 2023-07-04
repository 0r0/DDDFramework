using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Infrastructure.Config;
using DDDFramework.Infrastructure.Config.SettingModels;

namespace DDDFramework.Tests.Agents.MongoDBSynchronizerTest;

public class EventHandlerTest : IoCSupportedTest<OrderModule>
{
    private static readonly object?[]? Config =
    {
        new EventStoreSettings()
        {
            Url = "esdb://admin:changeit@localhost:2113?tls=false"
        },
        new MongoDbSettings()
        {
            Type = "OrderDto",
            Password = "",
            Url = "mongodb://localhost:27017",
            CollectionName = "Order",
            DatabaseName = "Order",
            UserName = "",
        }
    };

    public EventHandlerTest() : base(config: Config)
    {
    }

    [Fact]
    public async Task Dispatch_EventHandler_Successfully()
    {
        var builder = base.GetRegisteredContainer();
        await using var requestScope = builder.BeginLifetimeScope();

        var eventBus = new EventBus(requestScope);
        var orderCreated = new OrderCreated(new OrderId(Guid.NewGuid()),
            10, "Hi", false);
        Assert.True(eventBus.Publish(orderCreated).IsCompleted);
    }

    [Fact]
    public async Task Dispatch_EventHandler_with_argument_null_exception_when_scope_is_not_defined()
    {
        var eventBus = new EventBus(default);
        var orderCreated = new OrderCreated(new OrderId(Guid.NewGuid()),
            10, "Hi", false);
        await Assert.ThrowsAsync<ArgumentNullException>(() => eventBus.Publish(orderCreated));
    }
}