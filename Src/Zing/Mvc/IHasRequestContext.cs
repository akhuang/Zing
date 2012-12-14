using System.Web.Routing;

namespace Zing.Mvc {
    public interface IHasRequestContext {
        RequestContext RequestContext { get; }
    }
}