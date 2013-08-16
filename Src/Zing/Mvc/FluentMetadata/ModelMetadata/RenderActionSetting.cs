namespace Zing.Mvc
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Define a class that is used to store the render action element setting.
    /// </summary>
    public class RenderActionSetting : IModelMetadataAdditionalSetting
    {
        /// <summary>
        /// Get or sets the delegate which is used to invoke child action.
        /// </summary>
        public Func<HtmlHelper, IHtmlString> Action
        {
            get;
            set;
        }
    }
}