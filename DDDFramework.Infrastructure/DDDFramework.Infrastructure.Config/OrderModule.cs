using Autofac;
using DDDFramework.Application.Handlers;
using DDDFramework.Core.Application.Contracts;
using DDDFramework.Domain.EventStore;
using DDDFramework.Domain.Order;
using Persistence.ES;

namespace DDDFramework.Infrastructure.Config;

public class OrderModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterGeneric(typeof(EventSourceRepository<,>)).As(typeof(IEventSourceRepository<,>))
            .SingleInstance();
        builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();
        builder.RegisterAssemblyTypes(typeof(OrderCommandHandlers).Assembly)
            .As(type => type.GetInterfaces().Where(t => t.IsClosedTypeOf(typeof(ICommandHandler<>))))
            .InstancePerLifetimeScope();
    }
}