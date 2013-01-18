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

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void BeginRequest()
        {
            throw new NotImplementedException();
        }

        public void EndRequest()
        {
            throw new NotImplementedException();
        }
    }
}
