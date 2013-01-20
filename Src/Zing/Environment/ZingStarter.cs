using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Zing.Logging;

namespace Zing.Environment
{
    public class ZingStarter
    {
        public static IContainer CreateHostContainer(Action<ContainerBuilder> registrations)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new LoggingModule());
            builder.RegisterType<DefaultHostEnvironment>().As<IHostEnvironment>();
            builder.RegisterType<DefaultZingHost>().As<IZingHost>().SingleInstance();
            {


            }
            return builder.Build();
        }

        public static IZingHost CreateHost(Action<ContainerBuilder> registrations)
        {
            var container = CreateHostContainer(registrations);
            return container.Resolve<IZingHost>();
        }
    }


}
