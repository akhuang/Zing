using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Query;

namespace Zing.Modules.ViewFilter
{
    public interface IFilterEditor : IDependency
    {
        bool CanHandle(Type type);

        Action<IHqlExpressionFactory> Filter(string property, dynamic formState);

    }
}
