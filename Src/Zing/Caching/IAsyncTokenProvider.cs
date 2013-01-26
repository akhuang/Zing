using System;

namespace Zing.Caching {
    public interface IAsyncTokenProvider {
        IVolatileToken GetToken(Action<Action<IVolatileToken>> task);
    }
}