using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Logging
{
    /// <summary>
    /// Abstraction of the running environment
    /// </summary>
    public interface IHostEnvironment
    {
        bool IsFullTrust { get; }
        string MapPath(string virtualPath);

        bool IsAssemblyLoaded(string name);

        void RestartAppDomain();
    }
}
