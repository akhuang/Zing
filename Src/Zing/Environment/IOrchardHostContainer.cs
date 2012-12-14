namespace Zing.Environment {
    public interface IOrchardHostContainer {
        T Resolve<T>();
    }
}