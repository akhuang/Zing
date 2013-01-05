using System;
using NHibernate.Cfg;

namespace Zing.Data {
    public interface ISessionConfigurationCache : ISingletonDependency {
        Configuration GetConfiguration(Func<Configuration> builder);
    }
}