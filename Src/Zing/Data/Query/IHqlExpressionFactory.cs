using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query
{
    public interface IHqlExpressionFactory
    {
        void Eq(string propertyName, object value);
    }
}
