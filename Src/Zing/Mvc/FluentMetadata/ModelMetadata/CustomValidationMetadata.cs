namespace Zing.Mvc
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;

    /// <summary>
    /// Represents a class to store custom validation metadata.
    /// </summary>
    /// <typeparam name="T"></typeparam> 
    public class CustomValidationMetadata<T> : IModelValidationMetadata
        where T : ModelValidator
    {
        /// <summary>
        /// The configuration
        /// </summary>
        public Action<T> Configure
        {
            get;
            set;
        }

        /// <summary>
        /// The factory
        /// </summary>
        public Func<ModelMetadata, ControllerContext, T> Factory
        {
            get;
            set;
        }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <param name="metadata">The model metadata.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public ModelValidator CreateValidator(ExtendedModelMetadata metadata, ControllerContext context)
        {
            var validator = Factory(metadata, context);
            Configure(validator);
            return validator;
        }
    }
}