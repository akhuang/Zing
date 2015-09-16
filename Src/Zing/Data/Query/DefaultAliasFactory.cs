using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query
{
    public class DefaultAliasFactory : IAliasFactory
    {
        private readonly DefaultHqlQuery _query;
        public IAlias Current { get; private set; }

        public DefaultAliasFactory(DefaultHqlQuery query)
        {
            this._query = query;
            Current = _query.BindFromPath();
        }
        public IAliasFactory Property(string propertyName, string alias)
        {
            throw new NotImplementedException();
        }

        public IAliasFactory Named(string alias)
        {
            Current = _query.BindNamedAlias(alias);
            return this;
        }
    }
}
