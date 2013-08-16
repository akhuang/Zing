namespace Zing.Mvc
{
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;

    /// <summary>
    /// Represents a class to store compare validation metadata.
    /// </summary> 
    public class CompareValidationMetadata : ModelValidationMetadata
    {
        /// <summary>
        /// Gets or sets the other property.
        /// </summary>
        /// <value>The pattern.</value>
        public string OtherProperty { get; set; }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override ModelValidator CreateValidatorCore(ExtendedModelMetadata modelMetadata, ControllerContext context)
        {
            var attribute = new CompareAttribute(OtherProperty);
            PopulateErrorMessage(attribute);
            return new DataAnnotationsModelValidator<CompareAttribute>(modelMetadata, context, attribute);
        }
    }
}