using System.Linq;
using Autofac;
using DDDFramework.Core.Application.Contracts;
using DDDFramework.Core.CursorManager;
using DDDFramework.Infrastructure.Config;
using MongoDBSynchronizer.Handlers;

namespace MongoDBProjection;

public class ProjectionModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<EventBus>().As<IEventBus>();
        builder.RegisterType<Cursor>().As<ICursor>().SingleInstance();

        builder.RegisterAssemblyTypes(typeof(OrderEventHandlers).Assembly).As(type => type.GetInterfaces()
            .Where(a => a.IsClosedTypeOf(typeof(IEventHandler<>)))).InstancePerLifetimeScope();
        base.Load(builder);
    }

    
}