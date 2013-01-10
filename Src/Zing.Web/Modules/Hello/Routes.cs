using Zing.Mvc.Routes;
using System.Collections.Generic;
using System.Web.Routing;
using System.Web.Mvc;
namespace Hello
{
    public class Routes : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                             new RouteDescriptor {
                                                     Priority = -5,
                                                     Route = new Route(
                                                         "Admin",
                                                         new RouteValueDictionary {
                                                                                      {"area", "Hello"},
                                                                                      {"controller", "admin"},
                                                                                      {"action", "index"}
                                                                                  },
                                                         new RouteValueDictionary(),
                                                         new RouteValueDictionary {
                                                                                      {"area", "Dashboard"}
                                                                                  },
                                                         new MvcRouteHandler())
                                                 }
                         };
        }
    }
}