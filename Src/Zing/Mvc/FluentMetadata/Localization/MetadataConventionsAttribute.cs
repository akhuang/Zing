namespace Zing.Mvc
{
    using System;

    /// <summary>
    /// Allows to overwrite global resource type for metadata. Can be applied to ViewModel class or to whole assembly.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
    public class MetadataConventionsAttribute : Attribute
    {
        /// <summary>
        /// Creates <see cref="MetadataConventionsAttribute"/> attribute.
        /// </summary>
        public MetadataConventionsAttribute()
        {
        }

        /// <summary>
        /// Allows to ovewrite global resource type for metadata. Can be applied to ViewModel class or to whole assembly.
        /// </summary>
        /// <param name="resourceType"></param>
        public MetadataConventionsAttribute(Type resourceType)
        {
            ResourceType = resourceType;
        }

        /// <summary>
        /// Resource type to use for metadata class
        /// </summary>
        public Type ResourceType { get; set; }
    }
}
