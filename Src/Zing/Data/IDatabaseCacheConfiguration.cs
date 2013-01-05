using NHibernate.Cfg.Loquacious;

namespace Zing.Data {
    public interface IDatabaseCacheConfiguration : IDependency {
        void Configure(ICacheConfigurationProperties cache);
    }
}