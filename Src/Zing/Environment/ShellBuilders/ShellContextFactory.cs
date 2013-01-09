﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Configuration;
using Zing.Environment.Descriptor.Models;
using Zing.Environment.Descriptor;
using Zing.Logging;
using Zing.Environment.AutofacUtil;
using Autofac;
using Zing.Environment.ShellBuilderss;
using Zing.Environment.Extensions.Models;

namespace Zing.Environment.ShellBuilders
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

        /// <summary>
        /// Builds a shell context for an uninitialized Zing instance. Needed
        /// to display setup user interface.
        /// </summary>
        ShellContext CreateSetupContext(ShellSettings settings);

        /// <summary>
        /// Builds a shell context given a specific description of features and parameters.
        /// Shell's actual current descriptor has no effect. Does not use or update descriptor cache.
        /// </summary>
        ShellContext CreateDescribedContext(ShellSettings settings, ShellDescriptor shellDescriptor);

    }

    public class ShellContextFactory : IShellContextFactory
    {
        private readonly IShellDescriptorCache _shellDescriptorCache;
        private readonly ICompositionStrategy _compositionStrategy;
        private readonly IShellContainerFactory _shellContainerFactory;

        public ShellContextFactory(
            IShellDescriptorCache shellDescriptorCache,
            ICompositionStrategy compositionStrategy,
            IShellContainerFactory shellContainerFactory)
        {
            _shellDescriptorCache = shellDescriptorCache;
            _compositionStrategy = compositionStrategy;
            _shellContainerFactory = shellContainerFactory;
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public ShellContext CreateShellContext(ShellSettings settings)
        {

            Logger.Debug("Creating shell context for tenant {0}", settings.Name);

            var knownDescriptor = _shellDescriptorCache.Fetch(settings.Name);
            if (knownDescriptor == null)
            {
                Logger.Information("No descriptor cached. Starting with minimum components.");
                knownDescriptor = MinimumShellDescriptor();
            }

            var blueprint = _compositionStrategy.Compose(settings, knownDescriptor);
            var shellScope = _shellContainerFactory.CreateContainer(settings, blueprint);

            ShellDescriptor currentDescriptor = null;
            using (var standaloneEnvironment = shellScope.CreateWorkContextScope())
            {
                //var shellDescriptorManager = standaloneEnvironment.Resolve<IShellDescriptorManager>();
                //currentDescriptor = shellDescriptorManager.GetShellDescriptor();

                ShellDescriptor shellDescriptor = new ShellDescriptor()
                {
                    SerialNumber = 1
                };

                var descriptorFeatures = new List<ShellFeature>();
                descriptorFeatures.Add(new ShellFeature() { Name = "Zing.Framework" });
                descriptorFeatures.Add(new ShellFeature() { Name = "Setting" });
                descriptorFeatures.Add(new ShellFeature() { Name = "Hello" });

                shellDescriptor.Features = descriptorFeatures;

                currentDescriptor = shellDescriptor;
            }

            if (currentDescriptor != null && knownDescriptor.SerialNumber != currentDescriptor.SerialNumber)
            {
                Logger.Information("Newer descriptor obtained. Rebuilding shell container.");

                _shellDescriptorCache.Store(settings.Name, currentDescriptor);
                blueprint = _compositionStrategy.Compose(settings, currentDescriptor);
                shellScope.Dispose();
                shellScope = _shellContainerFactory.CreateContainer(settings, blueprint);
            }

            return new ShellContext
            {
                Settings = settings,
                Descriptor = currentDescriptor,
                Blueprint = blueprint,
                LifetimeScope = shellScope,
                Shell = shellScope.Resolve<IZingShell>(),
            };
        }

        private static ShellDescriptor MinimumShellDescriptor()
        {
            return new ShellDescriptor
            {
                SerialNumber = -1,
                Features = new[] {
                    new ShellFeature {Name = "Zing.Framework"},
                    new ShellFeature {Name = "Settings"},
                },
                Parameters = Enumerable.Empty<ShellParameter>(),
            };
        }

        public ShellContext CreateSetupContext(ShellSettings settings)
        {
            Logger.Debug("No shell settings available. Creating shell context for setup");

            var descriptor = new ShellDescriptor
            {
                SerialNumber = -1,
                Features = new[] {
                    new ShellFeature { Name = "Zing.Setup" },
                    new ShellFeature { Name = "Shapes" },
                    new ShellFeature { Name = "Zing.jQuery" },
                },
            };

            var blueprint = _compositionStrategy.Compose(settings, descriptor);
            var shellScope = _shellContainerFactory.CreateContainer(settings, blueprint);

            return new ShellContext
            {
                Settings = settings,
                Descriptor = descriptor,
                Blueprint = blueprint,
                LifetimeScope = shellScope,
                Shell = shellScope.Resolve<IZingShell>(),
            };
        }

        public ShellContext CreateDescribedContext(ShellSettings settings, ShellDescriptor shellDescriptor)
        {
            Logger.Debug("Creating described context for tenant {0}", settings.Name);

            var blueprint = _compositionStrategy.Compose(settings, shellDescriptor);
            var shellScope = _shellContainerFactory.CreateContainer(settings, blueprint);

            return new ShellContext
            {
                Settings = settings,
                Descriptor = shellDescriptor,
                Blueprint = blueprint,
                LifetimeScope = shellScope,
                Shell = shellScope.Resolve<IZingShell>(),
            };
        }
    }
}
