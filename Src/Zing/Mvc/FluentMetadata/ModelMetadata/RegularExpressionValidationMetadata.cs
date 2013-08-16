namespace Zing.Mvc
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;

    /// <summary>
    /// Represents a class to store regular expression validation metadata.
    /// </summary> 
    public class RegularExpressionValidationMetadata : ModelValidationMetadata
    {
        /// <summary>
        /// Gets or sets the pattern.
        /// </summary>
        /// <value>The pattern.</value>
        public string Pattern
        {
            get;
            set;
        }

        /// <summary>
        /// Creates the validator.
        /// </summary>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        protected override ModelValidator CreateValidatorCore(ExtendedModelMetadata modelMetadata, ControllerContext context)
        {
            var attribute = new RegularExpressionAttribute(Pattern);
            PopulateErrorMessage(attribute);
            return new RegularExpressionAttributeAdapter(modelMetadata, context, attribute);
        }
    }
}