﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.ShellBuilder.Models;

namespace Zing.Data.Providers
{
    public class SessionFactoryParameters : DataServiceParameters
    {
        public SessionFactoryParameters()
        {
            Configurers = Enumerable.Empty<ISessionConfigurationEvents>();
        }
        public IEnumerable<ISessionConfigurationEvents> Configurers { get; set; }
        public IEnumerable<RecordBlueprint> RecordDescriptors { get; set; }
        public bool CreateDatabase { get; set; }
    }
}
