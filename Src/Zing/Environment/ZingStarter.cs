using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Zing.Logging;
using Zing.UI.Resources;

namespace Zing.Environment
{
    public static class ZingStarter
    {
        public static IContainer CreateHostContainer(Action<ContainerBuilder> registrations)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new LoggingModule());
            builder.RegisterType<ResourceManager>().As<IResourceManager>();
            registrations(builder);

            var container = builder.Build();

            return container;
        }
    }
}
