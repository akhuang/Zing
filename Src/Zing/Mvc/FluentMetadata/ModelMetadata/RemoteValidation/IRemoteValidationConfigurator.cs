namespace Zing.Mvc
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Holds ModelMetadataItemBuilder&lt;TValue&gt; class
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface IRemoteValidationConfigurator<TValue>
    {
        /// <summary>
        /// ModelMetadataItemBuilder reference 
        /// </summary>
        ModelMetadataItemBuilder<TValue> ModelMetadataItemBuilder
        {
            get;
            set;
        }
    }
}