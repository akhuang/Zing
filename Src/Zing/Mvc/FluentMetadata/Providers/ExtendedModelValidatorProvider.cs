namespace Zing.Mvc
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;
    using JetBrains.Annotations;

    /// <summary>
    /// Defines a model validator provider which support fluent registration.
    /// </summary> 
    public class ExtendedModelValidatorProvider : ModelValidatorProvider
    {
        /// <summary>
        /// Gets a list of validators.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="context">The context.</param>
        /// <returns>A list of validators.</returns>
        [NotNull]
        public override IEnumerable<ModelValidator> GetValidators([NotNull] ModelMetadata metadata, [NotNull] ControllerContext context)
        {
            Invariant.IsNotNull(metadata, "metadata");
            Invariant.IsNotNull(context, "context");

            ExtendedModelMetadata extendedModelMetadata = metadata as ExtendedModelMetadata;

            return extendedModelMetadata != null && extendedModelMetadata.Metadata != null ?
                   extendedModelMetadata.Metadata.Validations.Select(validationMeta => validationMeta.CreateValidator(extendedModelMetadata, context)) :
                   Enumerable.Empty<ModelValidator>();
        }
    }
}