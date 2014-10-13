using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Extensions.Models;
using Zing.FileSystems.Dependencies;
using Zing.FileSystems.VirtualPath;
using Zing.Logging;

namespace Zing.Environment.Extensions.Loaders
{
    /// <summary>
    /// Load an extension by looking through the BuildManager referenced assemblies
    /// </summary>
    public class ReferencedExtensionLoader : ExtensionLoaderBase
    {
        private readonly IVirtualPathProvider _virtualPathProvider;
        private readonly IBuildManager _buildManager;

        public ReferencedExtensionLoader(IDependenciesFolder dependenciesFolder, IVirtualPathProvider virtualPathProvider, IBuildManager buildManager)
            : base(dependenciesFolder)
        {

            _virtualPathProvider = virtualPathProvider;
            _buildManager = buildManager;
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }
        public bool Disabled { get; set; }

        public override int Order { get { return 20; } }

        public override ExtensionProbeEntry Probe(ExtensionDescriptor descriptor)
        {
            if (Disabled)
                return null;

            var assembly = _buildManager.GetReferencedAssembly(descriptor.Id);
            if (assembly == null)
                return null;

            var assemblyPath = _virtualPathProvider.Combine("~/bin", descriptor.Id + ".dll");

            return new ExtensionProbeEntry
            {
                Descriptor = descriptor,
                Loader = this,
                Priority = 100, // Higher priority because assemblies in ~/bin always take precedence
                VirtualPath = assemblyPath,
                VirtualPathDependencies = new[] { assemblyPath },
            };
        }

        protected override ExtensionEntry LoadWorker(ExtensionDescriptor descriptor)
        {
            if (Disabled)
                return null;

            var assembly = _buildManager.GetReferencedAssembly(descriptor.Id);
            if (assembly == null)
                return null;

            Logger.Information("Loaded referenced extension \"{0}\": assembly name=\"{1}\"", descriptor.Name, assembly.FullName);

            return new ExtensionEntry
            {
                Descriptor = descriptor,
                Assembly = assembly,
                ExportedTypes = assembly.GetExportedTypes()
            };
        }
    }
}
