using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Zing.Logging;
using Zing.Data;
using Zing.Environment;

namespace Zing.Framework.Tests
{
    public class ContainerTestBase
    {
        protected IContainer _container;

        [SetUp]
        public virtual void Init()
        {
            var builder = new ContainerBuilder();
            Register(builder);
            _container = builder.Build();

            Resolve(_container);
        }

        protected virtual void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new LoggingModule());
            //builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new DataModule());
            builder.RegisterType<DefaultHostEnvironment>().As<IHostEnvironment>();
        }
        protected virtual void Resolve(ILifetimeScope container) { }
    }
}
