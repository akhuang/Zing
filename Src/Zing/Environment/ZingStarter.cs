﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Zing.Logging;
using Zing.Environment.Configuration; 
using Zing.FileSystems.AppData;
using Zing.Caching;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Zing.Mvc;
using Zing.Data;
using Zing.Security;  
using Zing.FileSystems.VirtualPath; 
using Zing.FileSystems; 
using System.Web.Compilation;
using System.Reflection;
using Autofac.Core;
using Zing.Utility.Extensions;
using System.Web.Hosting;
using System.IO; 

namespace Zing.Environment
{
    public class ZingStarter
    {
        public static IContainer CreateHostContainer(Action<ContainerBuilder> registrations, Action<ContainerBuilder> controllerRegisteration)
        {
            var builder = new ContainerBuilder();
            //builder.RegisterModule(new LoggingModule());
            //builder.RegisterModule(new DataModule());
            //builder.RegisterModule(new WorkContextModule());
            //builder.RegisterModule(new MvcModule());
            //builder.RegisterModule(new CacheModule());
            RegisterModule(builder);

            RegisterConfiguration(builder);
             
            //builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance(); 

            FluentMetadataConfiguration.RegisterEachConfigurationWithContainer(r => builder.RegisterType(r.MetadataConfigurationType).As(r.InterfaceType));

            //builder.RegisterModule(new FileSystemsModule());
            //builder.RegisterModule(new ExtensionsModule());

            builder.RegisterType<DefaultZingHost>().As<IZingHost>().SingleInstance();

            //builder.RegisterType<DefaultZingHost>().As<IZingHost>().SingleInstance();
            //{
            //    builder.RegisterType<ShellSettingsManager>().As<IShellSettingsManager>().SingleInstance();

            //    builder.RegisterType<ShellContextFactory>().As<IShellContextFactory>().SingleInstance();
            //    {
            //        builder.RegisterType<ShellDescriptorCache>().As<IShellDescriptorCache>().SingleInstance();
            //        builder.RegisterType<CompositionStrategy>().As<ICompositionStrategy>().SingleInstance();
            //        {
            //            builder.RegisterType<ExtensionLoaderCoordinator>().As<IExtensionLoaderCoordinator>();
            //            builder.RegisterType<ShellContainerRegistrations>().As<IShellContainerRegistrations>().SingleInstance();
            //        }
            //        builder.RegisterType<ShellContainerFactory>().As<IShellContainerFactory>().SingleInstance();
            //    }
            //}

            //builder.RegisterType<RunningShellTable>().As<IRunningShellTable>().SingleInstance();
            //builder.RegisterType<DefaultZingShell>().As<IZingShell>();//.InstancePerMatchingLifetimeScope("shell");
            builder.RegisterType<SessionConfigurationCache>().As<ISessionConfigurationCache>().SingleInstance();

            registrations(builder);
            controllerRegisteration(builder);

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>();

            //ControllerBuilder.Current.SetControllerFactory(new ZingControllerFactory());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        private static void RegisterConfiguration(ContainerBuilder builder)
        {
            string physicalFile = HostingEnvironment.MapPath("~/App_Data/Sites/Settings.txt");
            var setting = ShellSettingsSerializer.ParseSettings(File.ReadAllText(physicalFile));

            builder.Register(ctx => setting);
        }

        private static void RegisterModule(ContainerBuilder builder)
        {
            var assemblies = BuildManager.GetReferencedAssemblies().OfType<Assembly>().Where(x => x.FullName.ToLower().StartsWith("zing"));
            var modules = assemblies.SelectMany(x => x.ExportedTypes.Where(IsModule).Select(Activator.CreateInstance).Cast<IModule>());

            var dependencies = assemblies.SelectMany(x => x.ExportedTypes.Where(IsDependency));
            var records = BuildRecords(assemblies, builder, IsRecord);

            modules.Each(x => builder.RegisterModule(x));
            builder.Register(ctx => records);

            foreach (var item in dependencies)
            {
                var registration = builder.RegisterType(item);

                foreach (var interfaceType in item.GetInterfaces()
                    .Where(itf => typeof(IDependency).IsAssignableFrom(itf)))
                {
                    registration.As(interfaceType);
                }
            }
        }

        private static IEnumerable<RecordBlueprint> BuildRecords(IEnumerable<Assembly> assemblies, ContainerBuilder builder, Func<Type, bool> isRecord)
        {
            var records = assemblies.SelectMany(ass => ass.ExportedTypes.Where(IsRecord));

            foreach (var item in records)
            {
                yield return new RecordBlueprint()
                {
                    Type = item,
                    TableName = item.Name
                };
            }
        }

        private static bool IsRecord(Type type)
        {
            return ((type.Namespace ?? "").EndsWith(".Models") || (type.Namespace ?? "").EndsWith(".Records")) &&
                   type.GetProperty("Id") != null &&
                   (type.GetProperty("Id").GetAccessors() ?? Enumerable.Empty<MethodInfo>()).All(x => x.IsVirtual) &&
                   !type.IsSealed &&
                   !type.IsAbstract;
        }

        private static bool IsModule(Type type)
        {
            return typeof(IModule).IsAssignableFrom(type);
        }

        private static bool IsDependency(Type type)
        {
            return typeof(IDependency).IsAssignableFrom(type);
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
