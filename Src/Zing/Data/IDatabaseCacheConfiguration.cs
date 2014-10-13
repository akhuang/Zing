using NHibernate.Cfg.Loquacious;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data
{
    public interface IDatabaseCacheConfiguration : IDependency
    {
        void Configure(ICacheConfigurationProperties cache);
    }
}
