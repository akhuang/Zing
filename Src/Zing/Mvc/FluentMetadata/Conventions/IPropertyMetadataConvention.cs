namespace Zing.Mvc
{
    using System.Reflection;

    /// <summary>
    /// Interface for all convenstions
    /// </summary>
    public interface IPropertyMetadataConvention
    {
        /// <summary>
        /// Verifies that conventions can be applied to the given property
        /// </summary>
        /// <param name="propertyInfo">Target property information</param>
        /// <returns>true - if metadata can be accepted; otherwise, false</returns>
        bool CanBeAccepted(PropertyInfo propertyInfo);

        /// <summary>
        /// Creates a set of model metadata rules
        /// </summary>
        /// <param name="propertyInfo">Target property information</param>
        /// <returns>A instance of <see cref="ModelMetadataItem"/></returns>
        ModelMetadataItem CreateMetadataRules(PropertyInfo propertyInfo);
    }
}
