using System;
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
using System.Configuration;

namespace Zing.Environment
{
    public class ZingStarter
    {
        public static IContainer CreateHostContainer(Action<ContainerBuilder> registrations, Action<ContainerBuilder> controllerRegisteration)
        {
            var builder = new ContainerBuilder();

            RegisterModule(builder);

            RegisterConfiguration(builder);
            FluentMetadataConfiguration.RegisterEachConfigurationWithContainer(r => builder.RegisterType(r.MetadataConfigurationType).As(r.InterfaceType));

            builder.RegisterType<DefaultZingHost>().As<IZingHost>().SingleInstance();

            builder.RegisterType<SessionConfigurationCache>().As<ISessionConfigurationCache>().SingleInstance();

            registrations(builder);
            controllerRegisteration(builder);

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>();
            builder.RegisterModule<AutofacWebTypesModule>(); 
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        private static void RegisterConfiguration(ContainerBuilder builder)
        {
            //string physicalFile = HostingEnvironment.MapPath("~/App_Data/Sites/Settings.txt");
            //var setting = ShellSettingsSerializer.ParseSettings(File.ReadAllText(physicalFile));
            var defaultConn = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            var setting = new ShellSettings()
            {
                Name = "Default",
                DataProvider = defaultConn.ProviderName,
                DataConnectionString = defaultConn.ConnectionString,
                EncryptionAlgorithm = "AES",
                EncryptionKey = "06B215AF3BAFF334F4389A4CD49A5142A4C4A1520B1A3B18ACA5B8D0EAB30038",
                HashAlgorithm = "HMACSHA256",
                HashKey = "57F4FC5F8AB6E4B2A5810BAC0525F3AF08AECE85B1581E4E05D2DE0071342D6EF3614BE15E941284AEAB4C9F59459F53BD5D1DF07E31FD916CF8E04F62FA10AA"
            };

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

                    if (typeof(ISingletonDependency).IsAssignableFrom(interfaceType))
                    {
                        registration = registration.SingleInstance();
                    }
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
