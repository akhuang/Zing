namespace Zing.Mvc
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Hides IRemoteValidationConfigurator&lt;TValue&gt; from user
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    //[TypeForwardedFrom(KnownAssembly.MvcExtensions)]
    public abstract class AbstractRemoteValidationConfigurator<TValue> : IRemoteValidationConfigurator<TValue>
    {
        ModelMetadataItemBuilder<TValue> IRemoteValidationConfigurator<TValue>.ModelMetadataItemBuilder
        {
            get;
            set;
        }
    }
}