using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Environment.Configuration
{
    public interface IShellSettingsManager
    {
        IEnumerable<ShellSettings> LoadSettings();
        void SaveSettings(ShellSettings settings);
    }
}
