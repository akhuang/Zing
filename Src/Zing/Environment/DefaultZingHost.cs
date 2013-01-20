using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Logging;

namespace Zing.Environment
{
    public class DefaultZingHost : IZingHost
    {
        public ILogger Logger { get; set; }

        public DefaultZingHost()
        {
            Logger = NullLogger.Instance;
        }
        public void Initialize()
        {
            Logger.Information("Initializing");

            Logger.Information("Initialized");
        }

        public void BeginRequest()
        {
            Logger.Debug("BeginRequest");
        }

        public void EndRequest()
        {
            Logger.Debug("EndRequest");
        }
    }
}
