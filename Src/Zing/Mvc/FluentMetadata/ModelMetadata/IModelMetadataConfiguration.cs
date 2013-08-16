namespace Zing.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents an interface to store metadata data of a model.
    /// </summary> 
    public interface IModelMetadataConfiguration
    {
        /// <summary>
        /// Gets the type of the model.
        /// </summary>
        /// <value>The type of the model.</value>
        Type ModelType
        {
            get;
        }

        /// <summary>
        /// Gets the configurations.
        /// </summary>
        /// <value>The configurations.</value>
        IDictionary<string, ModelMetadataItem> Configurations
        {
            get;
        }
    }
}