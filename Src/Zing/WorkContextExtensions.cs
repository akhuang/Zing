using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Zing
{
    public static class WorkContextExtensions
    {
        public static WorkContext GetWorkContext(this ControllerContext controllerContext)
        {
            if (controllerContext == null)
                return null;

            return GetWorkContext(controllerContext.RequestContext);
        }

        public static WorkContext GetWorkContext(this RequestContext requestContext)
        {
            if (requestContext == null)
                return null;

            var routeData = requestContext.RouteData;
            if (routeData == null || routeData.DataTokens == null)
                return null;

            object workContextValue;
            if (!routeData.DataTokens.TryGetValue("IWorkContextAccessor", out workContextValue))
            {
                workContextValue = FindWorkContextInParent(routeData);
            }

            if (!(workContextValue is IWorkContextAccessor))
                return null;

            var workContextAccessor = (IWorkContextAccessor)workContextValue;
            return workContextAccessor.GetContext(requestContext.HttpContext);
        }

        private static object FindWorkContextInParent(RouteData routeData)
        {
            object parentViewContextValue;
            if (!routeData.DataTokens.TryGetValue("ParentActionViewContext", out parentViewContextValue)
                || !(parentViewContextValue is ViewContext))
            {
                return null;
            }

            var parentRouteData = ((ViewContext)parentViewContextValue).RouteData;
            if (parentRouteData == null || parentRouteData.DataTokens == null)
                return null;

            object workContextValue;
            if (!parentRouteData.DataTokens.TryGetValue("IWorkContextAccessor", out workContextValue))
            {
                workContextValue = FindWorkContextInParent(parentRouteData);
            }

            return workContextValue;
        }

    }
}
