using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data
{
    public interface ISessionConfigurationCache
    {
        Configuration GetConfiguration(Func<Configuration> builder);
    }
}
