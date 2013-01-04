using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Zing.Mvc
{
    public interface IHasRequestContext
    {
        RequestContext RequestContext { get; }
    }
}
