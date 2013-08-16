namespace Zing.Mvc
{
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;

    /// <summary>
    /// Represents an interface to store validation metadata.
    /// </summary> 
    public interface IModelValidationMetadata
    {
        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <param name="metadata">The model metadata.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        ModelValidator CreateValidator(ExtendedModelMetadata metadata, ControllerContext context);
    }
}