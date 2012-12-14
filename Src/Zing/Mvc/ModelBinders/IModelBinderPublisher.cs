using System.Collections.Generic;

namespace Zing.Mvc.ModelBinders {
    public interface IModelBinderPublisher : IDependency {
        void Publish(IEnumerable<ModelBinderDescriptor> binders);
    }
}