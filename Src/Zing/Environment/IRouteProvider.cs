using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Mvc.Routes;

namespace Zing.Environment
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
