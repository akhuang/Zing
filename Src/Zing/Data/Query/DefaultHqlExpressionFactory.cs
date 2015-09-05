using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query
{
    public class DefaultHqlExpressionFactory : IHqlExpressionFactory
    {
        public IHqlCriterion Criterion
        {
            get;
            private set;
        }
        public void Eq(string propertyName, object value)
        {
            Criterion = HqlRestrictions.Eq(propertyName, value);
        }
    }
}
