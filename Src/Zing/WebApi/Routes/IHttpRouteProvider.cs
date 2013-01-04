using System.Collections.Generic;
using Zing.Mvc.Routes;

namespace Zing.WebApi.Routes {
    public interface IHttpRouteProvider : IDependency {
        IEnumerable<RouteDescriptor> GetRoutes();
        void GetRoutes(ICollection<RouteDescriptor> routes);
    }
}
