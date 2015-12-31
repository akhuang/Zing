using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Configuration;
using Zing.Logging;

namespace Zing.Environment
{
    public class DefaultZingHost : IZingHost
    {
        private readonly object _syncLock = new object();
        public DefaultZingHost()
        {
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Initialize()
        {
            Logger.Information("Initializing");
            //BuildCurrent();
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
