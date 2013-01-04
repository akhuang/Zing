using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Caching;

namespace Zing.Environment.Extensions
{
    public interface IExtensionMonitoringCoordinator
    {
        void MonitorExtensions(Action<IVolatileToken> monitor);
    }
}
