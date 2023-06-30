using Autofac;
using DDDFramework.Core.Application.Contracts;
using DDDFramework.Tests.Agents.MongoDBSynchronizerTest.Handlers;

namespace DDDFramework.Tests.IOCModules;

public class OrderTestModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterAssemblyTypes(typeof(OrderEventHandlers).Assembly).As(type => type.GetInterfaces()
            .Where(a => a.IsClosedTypeOf(typeof(IEventHandler<>)))).InstancePerLifetimeScope();
    }
}