namespace Zing.Mvc
{
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;
    using JetBrains.Annotations;

    /// <summary>
    /// Extensions for <see cref="ModelMetadata"/> and <see cref="ViewDataDictionary"/> which add ability to retrive <see cref="RenderActionSetting"/> 
    /// </summary> 
    public static class RenderActionSettingExtensions
    {
        /// <summary>
        /// Retrives the <see cref="RenderActionSetting"/> from the <see cref="ModelMetadata"/>
        /// </summary>
        /// <param name="modelMetadata"> The model metadata </param>
        /// <returns></returns>
        [NotNull]
        public static RenderActionSetting GetRenderActionSetting(this ModelMetadata modelMetadata)
        {
            var extendedModelMetadata = modelMetadata as ExtendedModelMetadata;
            if (extendedModelMetadata == null)
            {
                return new RenderActionSetting();
            }

            return extendedModelMetadata.Metadata.GetAdditionalSettingOrCreateNew<RenderActionSetting>();
        }

        /// <summary>
        /// Retrives the <see cref="RenderActionSetting"/> from the <see cref="ViewDataDictionary"/>
        /// </summary>
        /// <param name="viewData"> The view data dicionary </param>
        /// <returns></returns>
        [NotNull]
        public static RenderActionSetting GetRenderActionSetting([NotNull] this ViewDataDictionary viewData)
        {
            Invariant.IsNotNull(viewData, "viewData");

            return GetRenderActionSetting(viewData.ModelMetadata);
        }
    }
}