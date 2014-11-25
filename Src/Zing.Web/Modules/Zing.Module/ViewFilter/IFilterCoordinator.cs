using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Query;

namespace Zing.Modules.ViewFilter
{
    public interface IFilterCoordinator
    {
        Action<IHqlExpressionFactory> Filter(Type type, string property, dynamic formState);
    }
}
