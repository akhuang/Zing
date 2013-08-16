namespace Zing.Mvc
{
    using System;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;

    /// <summary>
    /// </summary>
    public static class RemoteValidationExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="configure"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static ModelMetadataItemBuilder<TValue> Remote<TValue>(this ModelMetadataItemBuilder<TValue> self, [NotNull] Func<RemoteValidationConfigurator<TValue>, AbstractRemoteValidationConfigurator<TValue>> configure)
        {
            return Remote(self, configure, null, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="configure"></param>
        /// <param name="errorMessage"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static ModelMetadataItemBuilder<TValue> Remote<TValue>(this ModelMetadataItemBuilder<TValue> self, [NotNull] Func<RemoteValidationConfigurator<TValue>, AbstractRemoteValidationConfigurator<TValue>> configure, string errorMessage)
        {
            return Remote(self, configure, () => errorMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="configure"></param>
        /// <param name="errorMessage"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static ModelMetadataItemBuilder<TValue> Remote<TValue>(this ModelMetadataItemBuilder<TValue> self, [NotNull] Func<RemoteValidationConfigurator<TValue>, AbstractRemoteValidationConfigurator<TValue>> configure, Func<string> errorMessage)
        {
            return Remote(self, configure, errorMessage, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="configure"></param>
        /// <param name="errorMessageResourceName"></param>
        /// <param name="errorMessageResourceType"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static ModelMetadataItemBuilder<TValue> Remote<TValue>(this ModelMetadataItemBuilder<TValue> self, [NotNull] Func<RemoteValidationConfigurator<TValue>, AbstractRemoteValidationConfigurator<TValue>> configure, string errorMessageResourceName, Type errorMessageResourceType)
        {
            return Remote(self, configure, null, errorMessageResourceName, errorMessageResourceType);
        }

        private static ModelMetadataItemBuilder<TValue> Remote<TValue>(this ModelMetadataItemBuilder<TValue> self, [NotNull] Func<RemoteValidationConfigurator<TValue>, AbstractRemoteValidationConfigurator<TValue>> configure, Func<string> errorMessage, string errorMessageResourceName, Type errorMessageResourceType)
        {
            var settings = new RemoteValidationConfigurator<TValue>(self, errorMessage, errorMessageResourceName, errorMessageResourceType);
            var configurator = (IRemoteValidationConfigurator<TValue>)configure(settings);
            return configurator.ModelMetadataItemBuilder;
        }
    }
}
