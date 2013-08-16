﻿namespace Zing.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using JetBrains.Annotations;

    /// <summary>
    /// Defines a metadata provider which supports conventional DataAnnotations model registration.
    /// </summary>
    public class ConventionalDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        internal static readonly Lazy<DisplayNameTransformer> DisplayNameTransformer = new Lazy<DisplayNameTransformer>(() => new DisplayNameTransformer());
        internal static readonly Lazy<ValidationAttributeTransformer> ValidationAttributeTransformer = new Lazy<ValidationAttributeTransformer>(() => new ValidationAttributeTransformer());
        internal static readonly Lazy<DisplayAttributeTransformer> DisplayAttributeTransformer = new Lazy<DisplayAttributeTransformer>(() => new DisplayAttributeTransformer());

        /// <summary>
        /// Gets the metadata for the specified property.
        /// </summary>
        /// <returns>
        /// The metadata for the property.
        /// </returns>
        /// <param name="attributes">The attributes.</param>
        /// <param name="containerType">The type of the container.</param>
        /// <param name="modelAccessor">The model accessor.</param>
        /// <param name="modelType">The type of the model.</param>
        /// <param name="propertyName">The name of the property.</param>
        protected override ModelMetadata CreateMetadata([NotNull] IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            List<Attribute> newAttributes = null;
            if (LocalizationConventions.Enabled && containerType != null && !string.IsNullOrEmpty(propertyName))
            {
                var defaultResourceType = LocalizationConventions.GetDefaultResourceType(containerType);

                if (defaultResourceType != null)
                {
                    newAttributes = new List<Attribute>();

                    DisplayAttribute displayAttribute = null;
                    foreach (var attribute in attributes)
                    {
                        if (attribute is ValidationAttribute)
                        {
                            ValidationAttributeTransformer.Value.Transform((ValidationAttribute)attribute, containerType, propertyName, defaultResourceType);
                            newAttributes.Add(attribute);
                        }
                        else if (attribute is DisplayAttribute)
                        {
                            displayAttribute = attribute as DisplayAttribute;
                        }
                        else
                        {
                            newAttributes.Add(attribute);
                        }
                    }

                    // ensure DisplayAttribute and clone existing
                    displayAttribute = displayAttribute.Copy() ?? new DisplayAttribute();
                  
                    DisplayAttributeTransformer.Value.Transform(displayAttribute, containerType, propertyName, defaultResourceType);
                    newAttributes.Add(displayAttribute);
                }
            }

            var metadata = base.CreateMetadata(newAttributes ?? attributes, containerType, modelAccessor, modelType, propertyName);
            DisplayNameTransformer.Value.Transform(metadata);
            return metadata;
        }
    }
}
