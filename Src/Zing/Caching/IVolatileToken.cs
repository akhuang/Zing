namespace Zing.Caching {
    public interface IVolatileToken {
        bool IsCurrent { get; }
    }
}