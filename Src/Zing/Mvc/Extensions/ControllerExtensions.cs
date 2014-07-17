using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Zing.Utility.Extensions;

namespace Zing.Mvc.Extensions
{
    public static class ControllerExtensions
    {
        public static ActionResult RedirectLocal(this Controller controller, string redirectUrl)
        {
            return RedirectLocal(controller, redirectUrl, (string)null);
        }

        public static ActionResult RedirectLocal(this Controller controller, string redirectUrl, string defaultUrl)
        {
            if (controller.Request.IsLocalUrl(redirectUrl))
            {
                return new RedirectResult(redirectUrl);
            }

            return new RedirectResult(defaultUrl ?? "~/");
        }
    }
}
