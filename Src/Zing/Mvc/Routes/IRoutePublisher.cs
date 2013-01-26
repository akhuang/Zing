using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Mvc.Routes
{
    public interface IRoutePublisher : IDependency
    {
        void Publish(IEnumerable<RouteDescriptor> routes);
    }
}
