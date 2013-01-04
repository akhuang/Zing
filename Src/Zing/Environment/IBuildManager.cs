﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Zing.FileSystems.VirtualPath;
using System.Web.Compilation;

namespace Zing.Environment
{
    public interface IBuildManager : IDependency
    {
        IEnumerable<Assembly> GetReferencedAssemblies();
        bool HasReferencedAssembly(string name);
        Assembly GetReferencedAssembly(string name);
        Assembly GetCompiledAssembly(string virtualPath);
    }

    public class DefaultBuildManager : IBuildManager
    {
        private readonly IVirtualPathProvider _virtualPathProvider;
        private readonly IAssemblyLoader _assemblyLoader;

        public DefaultBuildManager(
            IVirtualPathProvider virtualPathProvider,
            IAssemblyLoader assemblyLoader)
        {

            _virtualPathProvider = virtualPathProvider;
            _assemblyLoader = assemblyLoader;
        }

        public IEnumerable<Assembly> GetReferencedAssemblies()
        {
            return BuildManager.GetReferencedAssemblies().OfType<Assembly>();
        }

        public bool HasReferencedAssembly(string name)
        {
            var assemblyPath = _virtualPathProvider.Combine("~/bin", name + ".dll");
            return _virtualPathProvider.FileExists(assemblyPath);
        }

        public Assembly GetReferencedAssembly(string name)
        {
            if (!HasReferencedAssembly(name))
                return null;

            return _assemblyLoader.Load(name);
        }


        public Assembly GetCompiledAssembly(string virtualPath)
        {
            try
            {
                return BuildManager.GetCompiledAssembly(virtualPath);
            }
            catch
            {
                return null;
            }

        }
    }
}
