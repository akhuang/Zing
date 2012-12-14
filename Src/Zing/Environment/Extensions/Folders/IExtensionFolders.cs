using System.Collections.Generic;
using Zing.Environment.Extensions.Models;

namespace Zing.Environment.Extensions.Folders {
    public interface IExtensionFolders {
        IEnumerable<ExtensionDescriptor> AvailableExtensions();
    }
}