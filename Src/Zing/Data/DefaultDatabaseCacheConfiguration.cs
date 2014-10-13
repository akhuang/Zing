using NHibernate.Cfg.Loquacious;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data
{
    public class DefaultDatabaseCacheConfiguration : IDatabaseCacheConfiguration
    {
        public void Configure(ICacheConfigurationProperties cache)
        {
            cache.UseQueryCache = false;
        }
    }
}
