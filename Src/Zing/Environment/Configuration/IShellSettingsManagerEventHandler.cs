using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Events;

namespace Zing.Environment.Configuration
{
    public interface IShellSettingsManagerEventHandler : IEventHandler
    {
        void Saved(ShellSettings settings);
    }
}
