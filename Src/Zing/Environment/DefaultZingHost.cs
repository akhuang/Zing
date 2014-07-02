using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Configuration;
using Zing.Environment.ShellBuilder;
using Zing.Logging;

namespace Zing.Environment
{
    public class DefaultZingHost : IZingHost
    {
        private readonly IShellSettingsManager _shellSettingsManager;
        private readonly IShellContextFactory _shellContextFactory;
        private readonly IRunningShellTable _runningShellTable;
        private readonly object _syncLock = new object();

        private IEnumerable<ShellContext> _shellContexts;

        public DefaultZingHost(IShellSettingsManager shellSettingsManager,
           IShellContextFactory shellContextFactory,
                  IRunningShellTable runningShellTable)
        {
            _shellSettingsManager = shellSettingsManager;
            _shellContextFactory = shellContextFactory;
            _runningShellTable = runningShellTable;
            //_processingEngine = processingEngine;
            //_extensionLoaderCoordinator = extensionLoaderCoordinator;
            //_extensionMonitoringCoordinator = extensionMonitoringCoordinator;
            //_cacheManager = cacheManager;
            //_hostLocalRestart = hostLocalRestart;
            //_tenantsToRestart = Enumerable.Empty<ShellSettings>();

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Initialize()
        {
            Logger.Information("Initializing");
            BuildCurrent();
            Logger.Information("Initialized");
        }

        IEnumerable<ShellContext> BuildCurrent()
        {
            if (_shellContexts == null)
            {
                lock (_syncLock)
                {
                    if (_shellContexts == null)
                    {
                        CreateAndActivateShells();
                    }
                }
            }

            return _shellContexts;
        }

        private void CreateAndActivateShells()
        {
            Logger.Information("Start creation of shells");

            var allSettings = _shellSettingsManager.LoadSettings().ToArray();

            if (allSettings.Any())
            {
                foreach (var setting in allSettings)
                {
                    try
                    {
                        var context = CreateShellContext(setting);
                        ActivateShell(context);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            Logger.Information("Done creating shells");
        }

        private void ActivateShell(ShellContext context)
        {
            Logger.Debug("Activating context for tenant {0}", context.Settings.Name);
            context.Shell.Activate();

            _shellContexts = (_shellContexts ?? Enumerable.Empty<ShellContext>())
                            .Concat(new[] { context }).ToArray();
            _runningShellTable.Add(context.Settings);
        }

        private ShellContext CreateShellContext(ShellSettings settings)
        {
            //if (settings.State.CurrentState == TenantState.State.Uninitialized)
            //{
            //    Logger.Debug("Creating shell context for tenant {0} setup", settings.Name);
            //    return _shellContextFactory.CreateSetupContext(settings);
            //}

            Logger.Debug("Creating shell context for tenant {0}", settings.Name);
            return _shellContextFactory.CreateShellContext(settings);
        }

        public ShellContext GetShellContext(ShellSettings shellSettings)
        {
            return BuildCurrent().SingleOrDefault(shellContext => shellContext.Settings.Name.Equals(shellSettings.Name));
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
