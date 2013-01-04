using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Mvc.Routes
{
    public interface IRouteProvider : IDependency
    {
        /// <summary>
        /// obsolete, prefer other format for extension methods
        /// </summary>
        IEnumerable<RouteDescriptor> GetRoutes();

        void GetRoutes(ICollection<RouteDescriptor> routes);
    }
}
