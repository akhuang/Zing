using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Providers
{
    public interface ISqlStatementProvider : ISingletonDependency
    {
        string DataProvider { get; }
        string GetStatement(string command);
    }
}
