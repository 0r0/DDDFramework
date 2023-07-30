using System.Diagnostics;
using Autofac;
using DDDFramework.Application.Handlers;
using DDDFramework.Application.Order;
using DDDFramework.Core.Application.Contracts;
using DDDFramework.Core.CursorManager;
using DDDFramework.Domain;
using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Domain.EventStore;
using DDDFramework.Domain.Order;
using DDDFramework.Infrastructure.Config.SettingModels;
using DDDFramework.Query.Contracts;
using DDDFramework.Query.Services;
using EventStore.Client;
using MongoDB.Driver;
using MongoDBSynchronizer.Handlers;
using Persistence.ES;

namespace DDDFramework.Infrastructure.Config;

public class OrderModule : Module
{
    private readonly EventStoreSettings? _eventStoreSettings;
    private readonly MongoDbSettings? _mongoDatabaseSettings;

    public OrderModule(EventStoreSettings? eventStoreSettings, MongoDbSettings? mongoDatabaseSettings)
    {
        _eventStoreSettings = eventStoreSettings ?? throw new
            NullReferenceException("event store connection string can not be null");
        _mongoDatabaseSettings = mongoDatabaseSettings ?? throw new
            NullReferenceException("mongodb connection string can not be null");
        ;
    }

    public OrderModule()
    {
    }


    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterGeneric(typeof(EventSourceRepository<,>)).As(typeof(IEventSourceRepository<,>))
            .SingleInstance();
        builder.RegisterType<CommandBus>().As<ICommandBus>().SingleInstance();
        builder.RegisterType<OrderArgFactory>().As<IOrderArgFactory>().SingleInstance();
        builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();
        builder.RegisterType<OrderService>().As<IOrderService>().SingleInstance();
        // builder.RegisterType<InMemoryEventStore>().As<IEventStore>().SingleInstance();
        builder.RegisterType<EventStoreDb>().As<IEventStore>().SingleInstance();
        builder.RegisterType<EventTypeResolver>().As<IEventTypeResolver>().SingleInstance().OnActivated(a =>
            a.Instance.AddTypesFromAssemblies(typeof(OrderCreated).Assembly));
        builder.RegisterType<AggregateRootFactory>().As<IAggregateRootFactory>().SingleInstance();
        builder.Register(GetEventStoreClient);
        builder.RegisterAssemblyTypes(typeof(OrderCommandHandlers).Assembly)
            .As(type => type.GetInterfaces().Where(t => t.IsClosedTypeOf(typeof(ICommandHandler<>))))
            .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(OrderEventHandlers).Assembly).As(type => type.GetInterfaces()
            .Where(a => a.IsClosedTypeOf(typeof(IEventHandler<>)))).InstancePerLifetimeScope();
        builder.Register(GetMongoClient<OrderDto>);

        builder.Register(a => GetMongoClient<OrderDto>(a).GetCollection<OrderDto>("order"));
        builder.RegisterGenericDecorator(typeof(CursorGenericEventHandlerDecorator<>), typeof(IEventHandler<>));
    }

    private EventStoreClient GetEventStoreClient(IComponentContext context)
    {
        Debug.Assert(_eventStoreSettings != null, nameof(_eventStoreSettings) + " != null");
        var settings = EventStoreClientSettings
            .Create(_eventStoreSettings.Url);

        var client = new EventStoreClient(settings);
        return client;
    }

    private IMongoDatabase GetMongoClient<TDto>(IComponentContext context)
    {
        Debug.Assert(_mongoDatabaseSettings != null, nameof(_mongoDatabaseSettings) + " != null");
        var client = new MongoClient(_mongoDatabaseSettings.Url);
        return client.GetDatabase(_mongoDatabaseSettings.DatabaseName);
    }
}