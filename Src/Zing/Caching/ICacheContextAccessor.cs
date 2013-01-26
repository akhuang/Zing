namespace Zing.Caching {
    public interface ICacheContextAccessor {
        IAcquireContext Current { get; set; }
    }
}