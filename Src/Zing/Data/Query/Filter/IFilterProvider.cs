using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query.Filter
{
    public interface IFilterProvider : IDependency
    {
        void Describe(DescribeFilterContext describe);
    }
}
