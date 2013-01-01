using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Zing.Mvc;
using Zing;
using Zing.Mvc.Spooling;
using Zing.UI.Resources;

namespace Zing.Mvc.ViewEngines.Razor
{

    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>, IZingViewPage
    {
        private ScriptRegister _scriptRegister;
        private ResourceRegister _stylesheetRegister;
        private object _display;
        private object _layout;
        private WorkContext _workContext;

        public dynamic Display { get { return _display; } }
        // review: (heskew) is it going to be a problem?
        public new dynamic Layout { get { return _layout; } }
        public WorkContext WorkContext { get { return _workContext; } }

        public override void InitHelpers()
        {
            base.InitHelpers();

            _workContext = ViewContext.GetWorkContext();

            //_display = DisplayHelperFactory.CreateHelper(ViewContext, this);
            //_layout = _workContext.Layout;
        }

        public ScriptRegister Script
        {
            get
            {
                return _scriptRegister ??
                    (_scriptRegister = new WebViewScriptRegister(this, Html.ViewDataContainer, ResourceManager));
            }
        }

        private IResourceManager _resourceManager;
        public IResourceManager ResourceManager
        {
            get
            {
                return _resourceManager ?? (_resourceManager = _workContext.Resolve<IResourceManager>());
            }
        }

        public ResourceRegister Style
        {
            get
            {
                return _stylesheetRegister ??
                    (_stylesheetRegister = new ResourceRegister(Html.ViewDataContainer, ResourceManager, "stylesheet"));
            }
        }

        public void RegisterImageSet(string imageSet, string style = "", int size = 16)
        {
            // hack to fake the style "alternate" for now so we don't have to change stylesheet names when this is hooked up
            // todo: (heskew) deal in shapes so we have real alternates 
            var imageSetStylesheet = !string.IsNullOrWhiteSpace(style)
                ? string.Format("{0}-{1}.css", imageSet, style)
                : string.Format("{0}.css", imageSet);
            Style.Include(imageSetStylesheet);
        }

        public virtual void RegisterLink(LinkEntry link)
        {
            ResourceManager.RegisterLink(link);
        }


        public void SetMeta(string name, string content)
        {
        }

        public bool HasText(object thing)
        {
            return !string.IsNullOrWhiteSpace(Convert.ToString(thing));
        }

        public IDisposable Capture(Action<IHtmlString> callback)
        {
            return new CaptureScope(this, callback);
        }

        class CaptureScope : IDisposable
        {
            readonly WebPageBase _viewPage;
            readonly Action<IHtmlString> _callback;

            public CaptureScope(WebPageBase viewPage, Action<IHtmlString> callback)
            {
                _viewPage = viewPage;
                _callback = callback;
                _viewPage.OutputStack.Push(new HtmlStringWriter());
            }

            void IDisposable.Dispose()
            {
                var writer = (HtmlStringWriter)_viewPage.OutputStack.Pop();
                _callback(writer);
            }
        }

        class WebViewScriptRegister : ScriptRegister
        {
            private readonly WebPageBase _viewPage;

            public WebViewScriptRegister(WebPageBase viewPage, IViewDataContainer container, IResourceManager resourceManager)
                : base(container, resourceManager)
            {
                _viewPage = viewPage;
            }

            public override IDisposable Head()
            {
                return new CaptureScope(_viewPage, s => ResourceManager.RegisterHeadScript(s.ToString()));
            }

            public override IDisposable Foot()
            {
                return new CaptureScope(_viewPage, s => ResourceManager.RegisterFootScript(s.ToString()));
            }
        }
    }

    public abstract class WebViewPage : WebViewPage<dynamic>
    {
    }
}
