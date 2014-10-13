using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Zing.Environment;
using Zing.WarmupStarter;
using Zing.Web.Controllers;
using Zing.Mvc;
using Zing.Modules.Users.ViewModels;
using System.Web.Optimization;
using Autofac.Integration.Mvc;
using Autofac.Builder;

namespace Zing.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Starter<IZingHost> _starter;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FluentMetadataConfiguration.Register();
            _starter = new Starter<IZingHost>(HostInitialization, HostBeginRequest, HostEndRequest);
            _starter.OnApplicationStart(this);

        }

        protected void Application_BeginRequest()
        {
            _starter.OnBeginRequest(this);
        }

        protected void Application_EndRequest()
        {
            _starter.OnEndRequest(this);
        }

        private static void HostBeginRequest(HttpApplication application, IZingHost host)
        {
            application.Context.Items["originalHttpContext"] = application.Context;
            host.BeginRequest();
        }

        private static void HostEndRequest(HttpApplication application, IZingHost host)
        {
            host.EndRequest();
        }

        private static IZingHost HostInitialization(HttpApplication application)
        {
            var host = ZingStarter.CreateHost(MvcSingletons, ControllerRegisteration);

            host.Initialize();

            // initialize shells to speed up the first dynamic query
            host.BeginRequest();
            host.EndRequest();

            return host;
        }

        static void ControllerRegisteration(ContainerBuilder builder)
        {
            //builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerMatchingLifetimeScope("shell");

            //foreach (var item in blueprint.Controllers)
            //{
            IEnumerable<Type> controllerTypes = typeof(MvcApplication).Assembly.GetExportedTypes().Where(t => typeof(IController).IsAssignableFrom(t) &&
                   t.Name.EndsWith("Controller", StringComparison.Ordinal));

            foreach (var item in controllerTypes)
            {
                var serviceKeyName = (item.Name).ToLowerInvariant();
                var serviceKeyType = item;
                RegisterType(builder, item)
                    .Keyed<IController>(serviceKeyName)
                    .Keyed<IController>(serviceKeyType)
                    .WithMetadata("ControllerType", item)
                    .InstancePerDependency()
                    ;
            }

            //}



            //return builder.RegisterAssemblyTypes(controllerAssemblies)
            //    .Where(t => typeof(IController).IsAssignableFrom(t) &&
            //        t.Name.EndsWith("Controller", StringComparison.Ordinal));
        }
        private static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterType(ContainerBuilder builder, Type item)
        {
            return builder.RegisterType(item)
                .WithProperty("Feature", item.Name)
                .WithMetadata("Feature", item.Name).InstancePerMatchingLifetimeScope("shell");
        }
        static void MvcSingletons(ContainerBuilder builder)
        {
            var assembly = typeof(UserViewModel).Assembly;
            builder.RegisterAssemblyModules(assembly);
            builder.Register(ctx => RouteTable.Routes).SingleInstance();
            builder.Register(ctx => ModelBinders.Binders).SingleInstance();
            builder.Register(ctx => ViewEngines.Engines).SingleInstance();


        }
    }
}