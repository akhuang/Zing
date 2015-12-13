﻿using Autofac;
using Autofac.Core;
using Autofac.Features.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Zing.Mvc.Extensions;

namespace Zing.Mvc
{
    /// <summary>
    /// Overrides the default controller factory to resolve controllers using LoC, based their areas and names.
    /// </summary>
    public class ZingControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Tries to resolve an instance for the controller associated with a given service key for the work context scope.
        /// </summary>
        /// <typeparam name="T">The type of the controller.</typeparam>
        /// <param name="workContext">The work context.</param>
        /// <param name="serviceKey">The service key for the controller.</param>
        /// <param name="instance">The controller instance.</param>
        /// <returns>True if the controller was resolved; false otherwise.</returns>
        protected bool TryResolve<T>(WorkContext workContext, object serviceKey, out T instance)
        {
            if (workContext != null && serviceKey != null)
            {
                var key = new KeyedService(serviceKey, typeof(T));
                object value;
                if (workContext.Resolve<ILifetimeScope>().TryResolveService(key, out value))
                {
                    instance = (T)value;
                    return true;
                }
            }

            instance = default(T);
            return false;
        }

        protected bool TryResolve<T>(WorkContext workContext, Type serviceType, out T instance)
        {
            if (workContext != null && serviceType != null)
            {
                //var key = new KeyedService(serviceType, typeof(T));

                object value;
                if (workContext.Resolve<ILifetimeScope>().TryResolveService(new TypedService(serviceType), out value))
                {
                    instance = (T)value;
                    return true;
                }
            }

            instance = default(T);
            return false;
        }


        /// <summary>
        /// Returns the controller type based on the name of both the controller and area.
        /// </summary>
        /// <param name="requestContext">The request context from where to fetch the route data containing the area.</param>
        /// <param name="controllerName">The controller name.</param>
        /// <returns>The controller type.</returns>
        /// <example>ControllerName: Item, Area: Containers would return the type for the ItemController class.</example>
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            //var routeData = requestContext.RouteData;
            var controllerType = base.GetControllerType(requestContext, controllerName);

            // Determine the area name for the request, and fall back to stock orchard controllers
            //var areaName = routeData.GetAreaName();

            //// Service name pattern matches the identification strategy
            //var serviceKey = (areaName + "/" + controllerName).ToLowerInvariant();
            //serviceKey = (controllerName + "Controller").ToLowerInvariant();
            // Now that the request container is known - try to resolve the controller information

            //Meta<Lazy<IController>> info;
            IController info;
            var workContext = requestContext.GetWorkContext();

            if (TryResolve(workContext, controllerType, out info))
            {
                //return (Type)info.Metadata["ControllerType"];
                return info.GetType();
            }



            return null;
        }

        /// <summary>
        /// Returns an instance of the controller.
        /// </summary>
        /// <param name="requestContext">The request context from where to fetch the route data containing the area.</param>
        /// <param name="controllerType">The controller type.</param>
        /// <returns>An instance of the controller if it's type is registered; null if otherwise.</returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller;
            var workContext = requestContext.GetWorkContext();
            if (TryResolve(workContext, controllerType, out controller))
            {
                return controller;
            }

            // fail as appropriate for MVC's expectations
            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}
