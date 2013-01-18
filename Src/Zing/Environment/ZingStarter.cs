using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Zing.Environment
{
    public class ZingStarter
    {
        public static IContainer CreateHostContainer(Action<ContainerBuilder> registrations)
        {
            var builder = new ContainerBuilder();

            return builder.Build();
        }

        public static IZingHost CreateHost(Action<ContainerBuilder> registrations)
        {
            var container = CreateHostContainer(registrations);
            return container.Resolve<IZingHost>();
        }
    }


}
