using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Zing.Logging;
using Zing.Environment.Configuration;
using Zing.Environment.ShellBuilder;
using Zing.FileSystems.AppData;
using Zing.Caching;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Zing.Mvc;
using Zing.Data;
using Zing.Security;


namespace Zing.Environment
{
    public class ZingStarter
    {
        public static IContainer CreateHostContainer(Action<ContainerBuilder> registrations)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new WorkContextModule());
            //builder.RegisterModule(new MvcModule());
            builder.RegisterType<DefaultHostEnvironment>().As<IHostEnvironment>();
            builder.RegisterType<AppDataFolderRoot>().As<IAppDataFolderRoot>().SingleInstance();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

            FluentMetadataConfiguration.RegisterEachConfigurationWithContainer(r => builder.RegisterType(r.MetadataConfigurationType).As(r.InterfaceType));

            RegisterVolatileProvider<AppDataFolder, IAppDataFolder>(builder);

            builder.RegisterType<DefaultZingHost>().As<IZingHost>().SingleInstance();
            {
                builder.RegisterType<ShellSettingsManager>().As<IShellSettingsManager>().SingleInstance();

                builder.RegisterType<ShellContextFactory>().As<IShellContextFactory>().SingleInstance();
                {
                    builder.RegisterType<ShellContainerFactory>().As<IShellContainerFactory>().SingleInstance();

                    builder.RegisterType<ShellContainerRegistrations>().As<IShellContainerRegistrations>().SingleInstance();
                }
            }

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>();

            builder.RegisterType<RunningShellTable>().As<IRunningShellTable>().SingleInstance();
            builder.RegisterType<DefaultZingShell>().As<IZingShell>().InstancePerMatchingLifetimeScope("shell");

            registrations(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        private static void RegisterVolatileProvider<TRegister, TService>(ContainerBuilder builder) where TService : IVolatileProvider
        {
            builder.RegisterType<TRegister>()
                .As<TService>()
                .As<IVolatileProvider>()
                .SingleInstance();
        }

        public static IZingHost CreateHost(Action<ContainerBuilder> registrations)
        {
            var container = CreateHostContainer(registrations);
            return container.Resolve<IZingHost>();
        }
    }


}
