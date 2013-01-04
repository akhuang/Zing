﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Caching;

namespace Zing.FileSystems.Dependencies
{
    public class ActivatedExtensionDescriptor
    {
        public string ExtensionId { get; set; }
        public string LoaderName { get; set; }
        public string VirtualPath { get; set; }
        public string Hash { get; set; }
    }

    public interface IExtensionDependenciesManager : IVolatileProvider
    {
        void StoreDependencies(IEnumerable<DependencyDescriptor> dependencyDescriptors, Func<DependencyDescriptor, string> fileHashProvider);

        IEnumerable<string> GetVirtualPathDependencies(string extensionId);
        ActivatedExtensionDescriptor GetDescriptor(string extensionId);
    }
}
