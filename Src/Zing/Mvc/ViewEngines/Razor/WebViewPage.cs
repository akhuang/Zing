using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Zing.Mvc;
using Zing;
using Zing.Mvc.Spooling;

namespace Zing.Mvc.ViewEngines.Razor
{

    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>, IZingViewPage
    {
        private object _display;
        private object _layout;
        private WorkContext _workContext;

        public dynamic Display { get { return _display; } }
        // review: (heskew) is it going to be a problem?
        public new dynamic Layout { get { return _layout; } }
        public WorkContext WorkContext { get { return _workContext; } }

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
    }

    public abstract class WebViewPage : WebViewPage<dynamic>
    {
    }
}
