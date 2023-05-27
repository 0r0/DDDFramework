using Autofac;
using DDDFramework.Application.Handlers;
using DDDFramework.Application.Order;
using DDDFramework.Core.Application.Contracts;
using DDDFramework.Domain;
using DDDFramework.Domain.Contracts.Order;
using DDDFramework.Domain.EventStore;
using DDDFramework.Domain.Order;
using DDDFramework.Query.Services;
using Persistence.ES;

namespace DDDFramework.Infrastructure.Config;

public class OrderModule : Module
{
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
        builder.RegisterAssemblyTypes(typeof(OrderCommandHandlers).Assembly)
            .As(type => type.GetInterfaces().Where(t => t.IsClosedTypeOf(typeof(ICommandHandler<>))))
            .InstancePerLifetimeScope();
    }
}