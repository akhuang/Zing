using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Zing.Data
{
    public interface ISessionLocator : IDependency
    {
        ISession For(Type entityType);
    }
}
