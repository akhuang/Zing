using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Zing.Mvc.Extensions;

namespace Zing.Mvc.Routes
{
    public class ShellRoute : RouteBase, IRouteWithArea
    {
        private readonly RouteBase _route;
        private readonly IWorkContextAccessor _workContextAccessor;

        public ShellRoute(RouteBase route, IWorkContextAccessor workContextAccessor)
        {
            _workContextAccessor = workContextAccessor;
            Area = route.GetAreaName();
            _route = route;
        }


        public override RouteData GetRouteData(System.Web.HttpContextBase httpContext)
        {
            var routeData = _route.GetRouteData(httpContext);

            if (routeData == null)
                return null;

            routeData.DataTokens["IWorkContextAccessor"] = _workContextAccessor;

            return routeData;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            throw new NotImplementedException();
        }

        public string Area
        {
            get;
            private set;
        }
    }
}
