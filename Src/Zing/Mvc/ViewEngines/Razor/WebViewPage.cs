using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.WebPages;

namespace Zing.Mvc.ViewEngines.Razor
{
    public abstract class WebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>, IZingViewPage
    {
        private object _display;
        private object _layout;
        private WorkContext _workContext;

        public WorkContext WorkContext { get { return _workContext; } }


        public override void InitHelpers()
        {
            base.InitHelpers();

            _workContext = ViewContext.GetWorkContext();
        }
    }

    public abstract class WebViewPage : WebViewPage<dynamic>
    {
    }
}
