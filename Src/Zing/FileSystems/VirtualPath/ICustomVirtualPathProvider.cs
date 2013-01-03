using System.Web.Hosting;

namespace Zing.FileSystems.VirtualPath
{
    public interface ICustomVirtualPathProvider {
        VirtualPathProvider Instance { get; }
    }
}