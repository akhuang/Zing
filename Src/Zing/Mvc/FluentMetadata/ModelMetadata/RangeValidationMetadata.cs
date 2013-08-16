namespace Zing.Mvc
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;
    using JetBrains.Annotations;

    /// <summary>
    /// Represents a class to store range validation metadata.
    /// </summary>
    /// <typeparam name="TValueType">The type of the value type.</typeparam> 
    public class RangeValidationMetadata<TValueType> : ModelValidationMetadata
    {
        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public TValueType Minimum
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public TValueType Maximum
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
            var attribute = new RangeAttribute(UnwrapNullable(typeof(TValueType)), Minimum.ToString(), Maximum.ToString());
            PopulateErrorMessage(attribute);
            return new RangeAttributeAdapter(modelMetadata, context, attribute);
        }

        private static Type UnwrapNullable([NotNull] Type type)
        {
            Invariant.IsNotNull(type, "type");

            return IsNullable(type)
                       ? type.GetGenericArguments().First()
                       : type;
        }

        private static bool IsNullable([NotNull] Type type)
        {
            Invariant.IsNotNull(type, "type");

            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
    }
}