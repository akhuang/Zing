using System;
using Orchard.Caching;

namespace Zing.Environment.Extensions {
    public interface IExtensionMonitoringCoordinator {
        void MonitorExtensions(Action<IVolatileToken> monitor);
    }
}