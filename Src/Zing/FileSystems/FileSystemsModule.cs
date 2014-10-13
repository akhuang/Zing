using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Caching;
using Zing.FileSystems.AppData;
using Zing.FileSystems.Dependencies;
using Zing.FileSystems.LockFile;
using Zing.FileSystems.VirtualPath;
using Zing.FileSystems.WebSite;
using Zing.Services;

namespace Zing.FileSystems
{
    public class FileSystemsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDataFolderRoot>().As<IAppDataFolderRoot>().SingleInstance();
            RegisterVolatileProvider<DefaultDependenciesFolder, IDependenciesFolder>(builder);
            RegisterVolatileProvider<DefaultVirtualPathProvider, IVirtualPathProvider>(builder);
      
            RegisterVolatileProvider<WebSiteFolder, IWebSiteFolder>(builder);
            RegisterVolatileProvider<AppDataFolder, IAppDataFolder>(builder);
            RegisterVolatileProvider<DefaultLockFileManager, ILockFileManager>(builder);
            RegisterVolatileProvider<Clock, IClock>(builder);
            RegisterVolatileProvider<DefaultDependenciesFolder, IDependenciesFolder>(builder);
            RegisterVolatileProvider<DefaultExtensionDependenciesManager, IExtensionDependenciesManager>(builder);
            RegisterVolatileProvider<DefaultAssemblyProbingFolder, IAssemblyProbingFolder>(builder);
            RegisterVolatileProvider<DefaultVirtualPathMonitor, IVirtualPathMonitor>(builder);
            RegisterVolatileProvider<DefaultVirtualPathProvider, IVirtualPathProvider>(builder);
        }


        private static void RegisterVolatileProvider<TRegister, TService>(ContainerBuilder builder) where TService : IVolatileProvider
        {
            builder.RegisterType<TRegister>()
                .As<TService>()
                .As<IVolatileProvider>()
                .SingleInstance();
        }
    }
}
