namespace Zing.Mvc
{
    using System;

    /// <summary>
    /// Holds parameters for <see cref="IModelConventionAcceptor"/>
    /// </summary>
    public class AcceptorContext
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="modelType">Type of view model</param>
        /// <param name="hasMetadataConfiguration">Indicates whether model has metadata configuration</param>
        public AcceptorContext(Type modelType, bool hasMetadataConfiguration)
        {
            ModelType = modelType;
            HasMetadataConfiguration = hasMetadataConfiguration;
        }

        /// <summary>
        /// Indicates whether <see cref="ModelType"/> has related <seealso cref="IModelMetadataConfiguration"/> implementation
        /// </summary>
        public bool HasMetadataConfiguration { get; private set; }

        /// <summary>
        /// Type of view model
        /// </summary>
        public Type ModelType { get; private set; }
    }
}
