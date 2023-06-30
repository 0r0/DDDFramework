using Autofac;
using Autofac.Core;

namespace DDDFramework.Tests;


    public class IoCSupportedTest<TModule> where TModule : IModule, new()
    {
        private IContainer _container;

        public IoCSupportedTest()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new TModule());

            _container = builder.Build();
        }

        protected TEntity Resolve<TEntity>()
        {
            
            return _container.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            _container.Dispose();
        }
    }
