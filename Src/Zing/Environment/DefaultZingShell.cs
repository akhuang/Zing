﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Logging;
using Zing.Mvc.Routes;

namespace Zing.Environment
{
    public class DefaultZingShell : IZingShell
    {
        //private readonly Func<Owned<IOrchardShellEvents>> _eventsFactory;
        private readonly IEnumerable<IRouteProvider> _routeProviders;
        //private readonly IEnumerable<IHttpRouteProvider> _httpRouteProviders;
        private readonly IRoutePublisher _routePublisher;
        //private readonly IEnumerable<IModelBinderProvider> _modelBinderProviders;
        //private readonly IModelBinderPublisher _modelBinderPublisher;
        //private readonly ISweepGenerator _sweepGenerator;

        public DefaultZingShell()
        {
            //_eventsFactory = eventsFactory;
            //_routeProviders = routeProviders;
            //_httpRouteProviders = httpRouteProviders;
            //_routePublisher = routePublisher;
            //_modelBinderProviders = modelBinderProviders;
            //_modelBinderPublisher = modelBinderPublisher;
            //_sweepGenerator = sweepGenerator;

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Activate()
        {
            //var allRoutes = new List<RouteDescriptor>();
            //allRoutes.AddRange(_routeProviders.SelectMany(provider => provider.GetRoutes()));
            //allRoutes.AddRange(_httpRouteProviders.SelectMany(provider => provider.GetRoutes()));

            //_routePublisher.Publish(allRoutes);
            //_modelBinderPublisher.Publish(_modelBinderProviders.SelectMany(provider => provider.GetModelBinders()));

            //using (var events = _eventsFactory())
            //{
            //    events.Value.Activated();
            //}

            //_sweepGenerator.Activate();
        }

        public void Terminate()
        {
            //SafelyTerminate(() =>
            //{
            //    using (var events = _eventsFactory())
            //    {
            //        SafelyTerminate(() => events.Value.Terminating());
            //    }
            //});

            //SafelyTerminate(() => _sweepGenerator.Terminate());
        }


        private void SafelyTerminate(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Logger.Error(e, "An unexcepted error occured while terminating the Shell");
            }
        }
    }
}
