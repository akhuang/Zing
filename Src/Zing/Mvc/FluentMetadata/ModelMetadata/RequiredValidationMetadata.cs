namespace Zing.Mvc
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;

    /// <summary>
    /// Represents a class to store required validation metadata.
    /// </summary>
    public class RequiredValidationMetadata : ModelValidationMetadata
    {
        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override ModelValidator CreateValidatorCore(ExtendedModelMetadata modelMetadata, ControllerContext context)
        {
            var attribute = new RequiredAttribute();
            PopulateErrorMessage(attribute);
            return new RequiredAttributeAdapter(modelMetadata, context, attribute);
        }
    }
}