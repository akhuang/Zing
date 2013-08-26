using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

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

        protected virtual void Register(ContainerBuilder builder) { }
        protected virtual void Resolve(ILifetimeScope container) { }
    }
}
