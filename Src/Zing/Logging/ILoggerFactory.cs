using System;

namespace Zing.Logging {
    public interface ILoggerFactory {
        ILogger CreateLogger(Type type);
    }
}