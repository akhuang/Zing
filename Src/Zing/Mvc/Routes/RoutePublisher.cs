using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.Http;
using Zing.Environment;
using Zing.Environment.Configuration;
using System.Web.SessionState;

namespace Zing.Mvc.Routes
{
    public class RoutePublisher : IRoutePublisher
    {
        private readonly RouteCollection _routeCollection;
        private readonly ShellSettings _shellSettings;
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly IRunningShellTable _runningShellTable;
        //private readonly IExtensionManager _extensionManager;

        public RoutePublisher(
            RouteCollection routeCollection,
            ShellSettings shellSettings,
            IWorkContextAccessor workContextAccessor,
            IRunningShellTable runningShellTable)
        {
            _routeCollection = routeCollection;
            _shellSettings = shellSettings;
            _workContextAccessor = workContextAccessor;
            _runningShellTable = runningShellTable;
            //_extensionManager = extensionManager;
        }

        public void Publish(IEnumerable<RouteDescriptor> routes)
        {
            using (_routeCollection.GetWriteLock())
            {
                // existing routes are removed while the collection is briefly inaccessable
                var routesArray = _routeCollection.ToArray();
                // new routes are added
                foreach (var routeDescriptor in routesArray)
                {
                    // Loading session state information. 
                    var defaultSessionState = SessionStateBehavior.Default;

                    //ExtensionDescriptor extensionDescriptor = null;
                    //if (routeDescriptor.Route is Route)
                    //{
                    //    object extensionId;
                    //    var route = routeDescriptor.Route as Route;
                    //    if (route.DataTokens != null && route.DataTokens.TryGetValue("area", out extensionId) ||
                    //       route.Defaults != null && route.Defaults.TryGetValue("area", out extensionId))
                    //    {
                    //        extensionDescriptor = _extensionManager.GetExtension(extensionId.ToString());
                    //    }
                    //}
                    //else if (routeDescriptor.Route is IRouteWithArea)
                    //{
                    //    var route = routeDescriptor.Route as IRouteWithArea;
                    //    extensionDescriptor = _extensionManager.GetExtension(route.Area);
                    //}

                    //if (extensionDescriptor != null)
                    //{
                    //    // if session state is not define explicitly, use the one define for the extension
                    //    if (routeDescriptor.SessionState == SessionStateBehavior.Default)
                    //    {
                    //        Enum.TryParse(extensionDescriptor.SessionState, true /*ignoreCase*/, out defaultSessionState);
                    //    }
                    //}

                    // Route-level setting overrides module-level setting (from manifest).
                    //var sessionStateBehavior = routeDescriptor.SessionState == SessionStateBehavior.Default ? defaultSessionState : routeDescriptor.SessionState;

                    //var shellRoute = new ShellRoute(routeDescriptor, _shellSettings, _workContextAccessor, _runningShellTable)
                    //{
                    //    IsHttpRoute = routeDescriptor is HttpRouteDescriptor,
                    //    SessionState = sessionStateBehavior
                    //};
                    //_routeCollection.Add(routeDescriptor.Name, shellRoute);
                }
            }
        }
    }
}
