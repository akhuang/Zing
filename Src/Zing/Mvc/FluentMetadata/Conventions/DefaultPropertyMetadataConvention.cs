namespace Zing.Mvc
{
    using System.Reflection;
    using JetBrains.Annotations;

    /// <summary>
    /// Default inplementation of <see cref="IPropertyMetadataConvention"/> class. 
    /// Contains common logic to create convention for metadata.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DefaultPropertyMetadataConvention<T> : IPropertyMetadataConvention
    {
        /// <summary>
        /// Verifies that conventions can be applied to the given property
        /// </summary>
        /// <param name="propertyInfo">Target property information</param>
        /// <returns>true - if metadata can be accepted; otherwise, false</returns>
        public bool CanBeAccepted([NotNull] PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType == typeof(T) && CanBeAcceptedCore(propertyInfo);
        }

        /// <summary>
        /// Creates a set of model metadata rules
        /// </summary>
        /// <param name="propertyInfo">Target property information</param>
        /// <returns>A instance of <see cref="ModelMetadataItem"/></returns>
        public ModelMetadataItem CreateMetadataRules(PropertyInfo propertyInfo)
        {
            var builder = new ModelMetadataItemBuilder<T>(new ModelMetadataItem());
            CreateMetadataRulesCore(builder);
            return builder.Item;
        }

        /// <summary>
        /// Verifies that conventions can be applied to the given property
        /// </summary>
        protected abstract bool CanBeAcceptedCore(PropertyInfo propertyInfo);

        /// <summary>
        /// Creates a set of model metadata rules
        /// </summary>
        protected abstract void CreateMetadataRulesCore(ModelMetadataItemBuilder<T> builder);
    }
}
