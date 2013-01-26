using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Zing.FileSystems.AppData;

namespace Zing.Environment.Configuration
{
    public class ShellSettingsManager : IShellSettingsManager
    {
        private readonly IAppDataFolder _appDataFolder;
        //private readonly IShellSettingsManagerEventHandler _events;

        public ShellSettingsManager(
            IAppDataFolder appDataFolder)
        {
            _appDataFolder = appDataFolder;
            //_events = events;

            //T = NullLocalizer.Instance;
        }

        IEnumerable<ShellSettings> IShellSettingsManager.LoadSettings()
        {
            return LoadSettings().ToArray();
        }


        IEnumerable<ShellSettings> LoadSettings()
        {
            var filePaths = _appDataFolder
                .ListDirectories("Sites")
                .SelectMany(path => _appDataFolder.ListFiles(path))
                .Where(path => string.Equals(Path.GetFileName(path), "Settings.txt", StringComparison.OrdinalIgnoreCase));

            foreach (var filePath in filePaths)
            {
                yield return ShellSettingsSerializer.ParseSettings(_appDataFolder.ReadFile(filePath));
            }
        }
    }
}
