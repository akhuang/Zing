using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Extensions.Folders;
using Zing.Environment.Extensions.Loaders;

namespace Zing.Environment.Extensions
{
    public class ExtensionsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DefaultCriticalErrorProvider>().As<ICriticalErrorProvider>();

            builder.RegisterType<ExtensionManager>().As<IExtensionManager>();

            builder.RegisterType<ExtensionManager>().As<IExtensionManager>().SingleInstance();
            {
                builder.RegisterType<ExtensionHarvester>().As<IExtensionHarvester>().SingleInstance();
                builder.RegisterType<ModuleFolders>().As<IExtensionFolders>().SingleInstance()
                    .WithParameter(new NamedParameter("paths", new[] { "~/Modules" }));
                builder.RegisterType<ReferencedExtensionLoader>().As<IExtensionLoader>().SingleInstance(); 
            }
        }
    }
}
