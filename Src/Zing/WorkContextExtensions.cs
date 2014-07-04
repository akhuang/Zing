﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;
using System.Web.Http.Controllers;
using Autofac;
using Zing.Environment;
using Zing.Environment.Configuration;
using Zing.Environment.ShellBuilder;

namespace Zing
{
    public static class WorkContextExtensions
    {
        public static WorkContext GetContext(this IWorkContextAccessor workContextAccessor, ControllerContext controllerContext)
        {
            return workContextAccessor.GetContext(controllerContext.RequestContext.HttpContext);
        }

        public static WorkContext GetWorkContext(this RequestContext requestContext)
        {
            if (requestContext == null)
                return null;

            var routeData = requestContext.RouteData;
            if (routeData == null || routeData.DataTokens == null)
                return null;

            object workContextValue;
            //if (!routeData.DataTokens.TryGetValue("IWorkContextAccessor", out workContextValue))
            //{
            //    workContextValue = FindWorkContextInParent(routeData);
            //}

            //if (!(workContextValue is IWorkContextAccessor))
            //    return null;
            var ctx = HttpContext.Current;
            IRunningShellTable runningShellTable = DependencyResolver.Current.GetService<IRunningShellTable>();
            ShellSettings shellSettings = runningShellTable.Match(new HttpContextWrapper(ctx));

            //IOrchardHost orchardHost = HostContainer.Resolve<IOrchardHost>();
            IZingHost zingHost = DependencyResolver.Current.GetService<IZingHost>();
            ShellContext shellContext = zingHost.GetShellContext(shellSettings);
            IWorkContextAccessor workContextAccessor = shellContext.LifetimeScope.Resolve<IWorkContextAccessor>();
            //WorkContext workContext = workContextAccessor.GetContext();

            //workContextValue = DependencyResolver.Current.GetService<IWorkContextAccessor>();

            //workContextAccessor = (IWorkContextAccessor)workContextValue;
            return workContextAccessor.GetContext(requestContext.HttpContext);
        }

        public static WorkContext GetWorkContext(this HttpControllerContext controllerContext)
        {
            if (controllerContext == null)
                return null;

            var routeData = controllerContext.RouteData;
            if (routeData == null || routeData.Values == null)
                return null;

            object workContextValue;
            if (!routeData.Values.TryGetValue("IWorkContextAccessor", out workContextValue))
            {
                return null;
            }

            if (workContextValue == null || !(workContextValue is IWorkContextAccessor))
                return null;

            var workContextAccessor = (IWorkContextAccessor)workContextValue;
            return workContextAccessor.GetContext();
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

        public static WorkContext GetWorkContext(this ControllerContext controllerContext)
        {
            if (controllerContext == null)
                return null;

            return GetWorkContext(controllerContext.RequestContext);
        }

        public static IWorkContextScope CreateWorkContextScope(this ILifetimeScope lifetimeScope, HttpContextBase httpContext)
        {
            return lifetimeScope.Resolve<IWorkContextAccessor>().CreateWorkContextScope(httpContext);
        }

        public static IWorkContextScope CreateWorkContextScope(this ILifetimeScope lifetimeScope)
        {
            return lifetimeScope.Resolve<IWorkContextAccessor>().CreateWorkContextScope();
        }
    }
}
