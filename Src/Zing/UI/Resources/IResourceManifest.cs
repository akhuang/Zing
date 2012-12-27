using System.Collections.Generic;

namespace Zing.UI.Resources {
    public interface IResourceManifest {
        ResourceDefinition DefineResource(string resourceType, string resourceName);
        string Name { get; }
        string BasePath { get; }
        IDictionary<string, ResourceDefinition> GetResources(string resourceType);
    }
}
