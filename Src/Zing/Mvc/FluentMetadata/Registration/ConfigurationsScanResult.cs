namespace Zing.Mvc
{
    using System;

    /// <summary>
    /// Result of performing a scan.
    /// </summary>
    public class ConfigurationsScanResult
    {
        /// <summary>
        /// Creates an instance of an ConfigurationsScanResult.
        /// </summary>
        public ConfigurationsScanResult(Type configurationType)
        {
            InterfaceType = typeof(IModelMetadataConfiguration);
            MetadataConfigurationType = configurationType;
        }

        /// <summary>
        /// <see cref="IModelMetadataConfiguration"/> type
        /// </summary>
        public Type InterfaceType { get; private set; }

        /// <summary>
        /// Implementation of <see cref="IModelMetadataConfiguration"/>.
        /// </summary>
        public Type MetadataConfigurationType { get; private set; }
    }
}
