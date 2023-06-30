using Autofac;
using Autofac.Core;

namespace DDDFramework.Tests;


    public class IoCSupportedTest<TModule> where TModule : IModule, new() 
    
    {
        private IContainer _container;

        public IoCSupportedTest(string config)
        {
            var builder = new ContainerBuilder();
           
                var module = (TModule)Activator.CreateInstance(typeof(TModule), args:config) ?? 
                             throw new NullReferenceException(nameof(TModule));

                builder.RegisterModule(module);
            

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

        protected IContainer GetRegisteredContainer()
        {
            return _container;
        }
        
    }
