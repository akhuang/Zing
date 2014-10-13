using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Providers
{
    public interface IDataServicesProviderFactory : IDependency
    {
        IDataServicesProvider CreateProvider(DataServiceParameters sessionFactoryParameters);
    }

}
