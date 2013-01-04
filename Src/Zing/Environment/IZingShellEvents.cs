using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Events;
using Zing.Environment.Extensions.Models;

namespace Zing.Environment
{
    public interface IZingShellEvents : IEventHandler
    {
        void Activated();
        void Terminating();
    }

    public interface IFeatureEventHandler : IEventHandler
    {
        void Installing(Feature feature);
        void Installed(Feature feature);
        void Enabling(Feature feature);
        void Enabled(Feature feature);
        void Disabling(Feature feature);
        void Disabled(Feature feature);
        void Uninstalling(Feature feature);
        void Uninstalled(Feature feature);
    }
}
