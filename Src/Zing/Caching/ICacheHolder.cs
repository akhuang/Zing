using System;

namespace Zing.Caching {
    public interface ICacheHolder : ISingletonDependency {
        ICache<TKey, TResult> GetCache<TKey, TResult>(Type component);
    }
}
