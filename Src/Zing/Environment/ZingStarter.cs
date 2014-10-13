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
using Zing.Environment.Extensions;
using Zing.Environment.Extensions.Loaders;
using Zing.FileSystems.Dependencies;
using Zing.FileSystems.VirtualPath;
using Zing.Environment.Extensions.Folders;
using Zing.FileSystems;
using Zing.Environment.Descriptor;


namespace Zing.Environment
{
    public class ZingStarter
    {
        public static IContainer CreateHostContainer(Action<ContainerBuilder> registrations, Action<ContainerBuilder> controllerRegisteration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new LoggingModule());
            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new WorkContextModule());
            builder.RegisterModule(new MvcModule());
            builder.RegisterModule(new CacheModule());

            builder.RegisterType<DefaultHostEnvironment>().As<IHostEnvironment>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<DefaultAssemblyLoader>().As<IAssemblyLoader>().SingleInstance();

            FluentMetadataConfiguration.RegisterEachConfigurationWithContainer(r => builder.RegisterType(r.MetadataConfigurationType).As(r.InterfaceType));

            builder.RegisterModule(new FileSystemsModule());
            builder.RegisterModule(new ExtensionsModule());

            builder.RegisterType<DefaultZingHost>().As<IZingHost>().SingleInstance();
            {
                builder.RegisterType<ShellSettingsManager>().As<IShellSettingsManager>().SingleInstance();

                builder.RegisterType<ShellContextFactory>().As<IShellContextFactory>().SingleInstance();
                {
                    builder.RegisterType<ShellDescriptorCache>().As<IShellDescriptorCache>().SingleInstance();
                    builder.RegisterType<CompositionStrategy>().As<ICompositionStrategy>().SingleInstance();
                    {
                        builder.RegisterType<ExtensionLoaderCoordinator>().As<IExtensionLoaderCoordinator>();
                        builder.RegisterType<ShellContainerRegistrations>().As<IShellContainerRegistrations>().SingleInstance();
                    }
                    builder.RegisterType<ShellContainerFactory>().As<IShellContainerFactory>().SingleInstance();
                }
            }

            builder.RegisterType<RunningShellTable>().As<IRunningShellTable>().SingleInstance();
            builder.RegisterType<DefaultZingShell>().As<IZingShell>().InstancePerMatchingLifetimeScope("shell");
            builder.RegisterType<SessionConfigurationCache>().As<ISessionConfigurationCache>().InstancePerMatchingLifetimeScope("shell");

            registrations(builder);
            controllerRegisteration(builder);

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>();

            ControllerBuilder.Current.SetControllerFactory(new ZingControllerFactory());

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

        public static IZingHost CreateHost(Action<ContainerBuilder> registrations, Action<ContainerBuilder> controllerRegisteration)
        {
            var container = CreateHostContainer(registrations, controllerRegisteration);
            return container.Resolve<IZingHost>();
        }
    }


}
