namespace Zing.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents an interface to store all the metadata of the models.
    /// </summary> 
    public interface IModelMetadataRegistry
    {
        /// <summary>
        /// Register a new convention
        /// </summary>
        /// <param name="convention"><see cref="IPropertyMetadataConvention"/> class</param>
        void RegisterConvention(IPropertyMetadataConvention convention);

        /// <summary>
        /// Registers the model type metadata.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="metadataItem">The metadata.</param>
        void RegisterModel(Type modelType, ModelMetadataItem metadataItem);

        /// <summary>
        /// Registers the specified model type properties metadata.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="metadataItems">The metadata dictionary.</param>
        void RegisterModelProperties(Type modelType, IDictionary<string, ModelMetadataItem> metadataItems);

        /// <summary>
        /// Gets the model metadata.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <returns></returns>
        ModelMetadataItem GetModelMetadata(Type modelType);

        /// <summary>
        /// Gets the model property metadata.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        ModelMetadataItem GetModelPropertyMetadata(Type modelType, string propertyName);

        /// <summary>
        /// Gets the model properties metadata.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <returns></returns>
        IDictionary<string, ModelMetadataItem> GetModelPropertiesMetadata(Type modelType);
    }
}