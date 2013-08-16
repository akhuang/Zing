﻿namespace Zing.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using JetBrains.Annotations;

    /// <summary>
    /// <see cref="Assembly"/> class extensions
    /// </summary>
    internal static class AssemblyExtensions
    {
        /// <summary>
        /// Get all loadable types 
        /// from the given assembly
        /// </summary>
        /// <param name="assembly">assembly to scan</param>
        /// <returns>List of loadable types</returns>
        [NotNull,DebuggerStepThrough]
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            IEnumerable<Type> types = null;
            if (assembly != null)
            {
                try
                {
                    types = assembly.GetTypes().Where(t => t != null);
                }
                catch (ReflectionTypeLoadException e)
                {
                    types = e.Types.Where(t => t != null);
                }
            }

            return types ?? Enumerable.Empty<Type>();
        }
    }
}