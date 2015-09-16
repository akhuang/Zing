using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Data.Query.Models;

namespace Zing.Data.Query.Services
{
    public interface IHqlQueryManager : IDependency
    {
        void GetQuery(IHqlQuery query, QueryRecord queryRecord);
    }
}
