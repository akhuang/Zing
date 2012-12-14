using Orchard.Events;

namespace Zing.Environment.State {
    public interface IShellStateManagerEventHandler : IEventHandler {
        void ApplyChanges();
    }
}