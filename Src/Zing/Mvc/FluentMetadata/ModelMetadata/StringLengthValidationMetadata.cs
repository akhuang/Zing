namespace Zing.Mvc
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;

    /// <summary>
    /// Represents a class to store string length validation metadata.
    /// </summary>
    public class StringLengthValidationMetadata : ModelValidationMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringLengthValidationMetadata"/> class
        /// </summary>
        public StringLengthValidationMetadata()
        {
            Maximum = int.MaxValue;
            Minimum = 0;
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
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
            var attribute = new StringLengthAttribute(Maximum)
                                {
                                    MinimumLength = Minimum
                                };
            PopulateErrorMessage(attribute);
            return new StringLengthAttributeAdapter(modelMetadata, context, attribute);
        }
    }
}