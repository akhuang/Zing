namespace Zing.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using JetBrains.Annotations;

    /// <summary>
    /// Defines a class which is used to register the default <seealso cref="ModelMetadataProvider"/>.
    /// </summary>
    public static class FluentMetadataConfiguration
    {
        private static ModelMetadataRegistrar registrar;
        private static bool registredWithContainer;

        /// <summary>
        /// Current momel metadata registry
        /// </summary>
        public static IModelMetadataRegistry Registry
        {
            get
            {
                return Registrar.Registry;
            }
        }

        /// <summary>
        /// Instance of <see cref="ModelMetadataRegistrar"/> type
        /// </summary>
        private static ModelMetadataRegistrar Registrar
        {
            get
            {
                return registrar ?? (registrar = new ModelMetadataRegistrar(new ModelMetadataRegistry()));
            }
        }

        /// <summary>
        /// Allows to define custom factory to contruct model metadata configuration classes
        /// </summary>
        /// <param name="configurationFactory">A factory to instantiate <see cref="IModelMetadataConfiguration"/> classes</param>
        [NotNull]
        public static IRegistrar ConstructMetadataUsing([NotNull] Func<IEnumerable<IModelMetadataConfiguration>> configurationFactory)
        {
            Invariant.IsNotNull(configurationFactory, "configurationFactory");
            return Registrar.ConstructMetadataUsing(configurationFactory);
        }

        /// <summary>
        /// Set factory to DependencyResolver
        /// </summary>
        [NotNull]
        public static IRegistrar ConstructMetadataUsingDependencyResolver()
        {
            return ConstructMetadataUsing(() => DependencyResolver.Current.GetServices<IModelMetadataConfiguration>());
        }

        /// <summary>
        /// Registers metadata provider and model metadata configuration classes
        /// </summary>
        public static void Register()
        {
            if (!Registrar.ConfigurationFactoryDefined)
            {
                if (registredWithContainer)
                {
                    ConstructMetadataUsingDependencyResolver();
                }
                else
                {
                    Registrar.ConstructMetadataUsing(
                        () =>
                        ConfigurationsScanner
                            .GetMetadataClasses(From.AllAssemblies())
                            .Select(s => (IModelMetadataConfiguration)Activator.CreateInstance(s.MetadataConfigurationType)));
                }
            }

            Registrar.Register();
        }

        /// <summary>
        /// Registers <see cref="IModelMetadataConfiguration"/> classes in IoC
        /// </summary>
        /// <param name="registerFoundConfiguration">
        /// Register configuration via IoC container. 
        /// <example>
        /// <br/><b>Example:</b>
        /// <br/>
        /// <br/>Autofac:<br/>
        /// .RegisterConfigurationsWithContainer(r => container.RegisterType(r.MetadataConfigurationType).As(r.InterfaceType))
        /// <br/><br/>
        /// Windsor:<br/>
        /// .RegisterConfigurationsWithContainer(r => container.Register(Component.For(r.InterfaceType).ImplementedBy(r.MetadataConfigurationType).LifeStyle.Transient))
        /// </example>
        /// </param>
        /// <returns></returns>
        public static ModelMetadataRegistrar RegisterEachConfigurationWithContainer([NotNull] Action<ConfigurationsScanResult> registerFoundConfiguration)
        {
            return RegisterEachConfigurationWithContainer(From.AllAssemblies(), registerFoundConfiguration);
        }

        /// <summary>
        /// Registers <see cref="IModelMetadataConfiguration"/> classes in IoC
        /// </summary>
        /// <param name="forTypesInAssembly">Assemblies to scan for <see cref="IModelMetadataConfiguration"/> implementations</param>
        /// <param name="registerFoundConfiguration">
        /// Register configuration via IoC container. 
        /// <br/>
        /// ------------
        /// <br/><b>Example:</b>
        /// <br/>---<br/>
        /// <br/>Autofac:<br/>
        /// .RegisterConfigurationsWithContainer(r => container.RegisterType(r.MetadataConfigurationType).As(r.InterfaceType))
        /// <br/>---<br/>
        /// Windsor:<br/>
        /// .RegisterConfigurationsWithContainer(r => container.Register(Component.For(r.InterfaceType).ImplementedBy(r.MetadataConfigurationType).LifeStyle.Transient))
        /// </param>
        /// <returns></returns>
        public static ModelMetadataRegistrar RegisterEachConfigurationWithContainer([NotNull] IEnumerable<Assembly> forTypesInAssembly, [NotNull] Action<ConfigurationsScanResult> registerFoundConfiguration)
        {
            Invariant.IsNotNull(forTypesInAssembly, "forTypesInAssembly");
            Invariant.IsNotNull(registerFoundConfiguration, "registerConfigurationWithIoC");

            ConfigurationsScanner
                .GetMetadataClasses(forTypesInAssembly)
                .ForEach(registerFoundConfiguration);
            registredWithContainer = true;
            return Registrar;
        }

        /// <summary>
        /// Allows to set custom <see cref="IModelMetadataRegistry"/> implementation
        /// </summary>
        public static void SetModelMetadataRegistry(IModelMetadataRegistry registry)
        {
            Registrar.Registry = registry;
        }
    }
}
