using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Environment
{
    /// <summary>
    /// Interface implemented by shims for ASP.NET singleton services that
    /// need access to the HostContainer instance.
    /// </summary>
    public interface IShim
    {
        IZingHostContainer HostContainer { get; set; }
    }
}
