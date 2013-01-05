using NHibernate.Cfg.Loquacious;

namespace Zing.Data {
    public class DefaultDatabaseCacheConfiguration : IDatabaseCacheConfiguration {
        public void Configure(ICacheConfigurationProperties cache) {
            cache.UseQueryCache = false;
        }
    }
}