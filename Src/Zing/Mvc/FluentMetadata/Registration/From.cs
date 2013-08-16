namespace Zing.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Compilation;
    using JetBrains.Annotations;

    /// <summary>
    /// Helps with configuration types search
    /// </summary>
    public static class From
    {
        /// <summary>
        /// Register configuration types from all assemblies
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public static IEnumerable<Assembly> AllAssemblies()
        {
            return BuildManager.GetReferencedAssemblies().Cast<Assembly>().Where(assembly => !assembly.GlobalAssemblyCache).ToList();
        }

        /// <summary>
        /// Register configuration types from the assembly containing type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Assembly> AssemblyContainingType([NotNull] Type type)
        {
            Invariant.IsNotNull(type, "type");
            yield return type.Assembly;
        }

        /// <summary>
        /// Register configuration types from the assembly containing type
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public static IEnumerable<Assembly> AssemblyContainingType<T>()
        {
            return AssemblyContainingType(typeof(T));
        }

        /// <summary>
        /// Register configuration types from current assembly
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public static IEnumerable<Assembly> ThisAssembly()
        {
            return new[] { Assembly.GetCallingAssembly() };
        }
    }
}
