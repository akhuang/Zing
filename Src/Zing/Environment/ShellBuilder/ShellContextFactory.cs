using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Configuration;
using Zing.Logging;
using Autofac;

namespace Zing.Environment.ShellBuilder
{
    /// <summary>
    /// High-level coordinator that exercises other component capabilities to
    /// build all of the artifacts for a running shell given a tenant settings.
    /// </summary>
    public interface IShellContextFactory
    {
        /// <summary>
        /// Builds a shell context given a specific tenant settings structure
        /// </summary>
        ShellContext CreateShellContext(ShellSettings settings);

        ///// <summary>
        ///// Builds a shell context for an uninitialized Orchard instance. Needed
        ///// to display setup user interface.
        ///// </summary>
        //ShellContext CreateSetupContext(ShellSettings settings);

        ///// <summary>
        ///// Builds a shell context given a specific description of features and parameters.
        ///// Shell's actual current descriptor has no effect. Does not use or update descriptor cache.
        ///// </summary>
        //ShellContext CreateDescribedContext(ShellSettings settings, ShellDescriptor shellDescriptor);

    }

    public class ShellContextFactory : IShellContextFactory
    {
        private readonly IShellContainerFactory _shellContainerFactory;

        public ShellContextFactory(IShellContainerFactory shellContainerFactory)
        {
            _shellContainerFactory = shellContainerFactory;
            Logger = NullLogger.Instance;
        }
        public ILogger Logger { get; set; }

        public ShellContext CreateShellContext(ShellSettings settings)
        {
            Logger.Debug("Creating shell context for tenant {0}", settings.Name);

            //返回一个shell的生命周期
            var shellScope = _shellContainerFactory.CreateContainer(settings);
            //ShellDescriptor currentDescriptor;
            using (var standaloneEnvironment = shellScope.CreateWorkContextScope())
            {
                //var shellDescriptorManager = standaloneEnvironment.Resolve<IShellDescriptorManager>();
                //currentDescriptor = shellDescriptorManager.GetShellDescriptor();
            }

            return new ShellContext
            {
                Settings = settings,
                LifetimeScope = shellScope,
                Shell = shellScope.Resolve<IZingShell>(),
            };
        }
    }
}
