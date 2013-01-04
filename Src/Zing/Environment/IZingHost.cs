﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Configuration;
using Zing.Environment.ShellBuilders;

namespace Zing.Environment
{
    public interface IZingHost
    {
        /// <summary>
        /// Called once on startup to configure app domain, and load/apply existing shell configuration
        /// </summary>
        void Initialize();

        /// <summary>
        /// Called externally when there is explicit knowledge that the list of installed
        /// modules/extensions has changed, and they need to be reloaded.
        /// </summary>
        void ReloadExtensions();

        /// <summary>
        /// Called each time a request begins to offer a just-in-time reinitialization point
        /// </summary>
        void BeginRequest();

        /// <summary>
        /// Called each time a request ends to deterministically commit and dispose outstanding activity
        /// </summary>
        void EndRequest();

        ShellContext GetShellContext(ShellSettings shellSettings);

        /// <summary>
        /// Can be used to build an temporary self-contained instance of a shell's configured code.
        /// Services may be resolved from within this instance to configure and initialize it's storage.
        /// </summary>
        IWorkContextScope CreateStandaloneEnvironment(ShellSettings shellSettings);
    }
}
