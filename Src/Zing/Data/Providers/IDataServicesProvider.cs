using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Providers
{
    public interface IDataServicesProvider : ITransientDependency
    {
        Configuration BuildConfiguration(SessionFactoryParameters sessionFactoryParameters);
        IPersistenceConfigurer GetPersistenceConfigurer(bool createDatabase);
    }
}
