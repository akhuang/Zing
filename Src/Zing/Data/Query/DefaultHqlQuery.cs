using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query
{
    public class DefaultHqlQuery : IHqlQuery
    {
        protected IJoin _from;
        protected readonly List<Tuple<IAlias, Action<IHqlExpressionFactory>>> _wheres = new List<Tuple<IAlias, Action<IHqlExpressionFactory>>>();

        private readonly ISession _session;

        string TableName
        {
            get;
            private set;
        }

        public DefaultHqlQuery(string tableName, ISession session)
        {
            this.TableName = tableName;
            this._session = session;
        }
        public int Count()
        {
            throw new NotImplementedException();
        }

        public string ToHql()
        {
            var sb = new StringBuilder();

        }

        public IHqlQuery Where(Action<IAliasFactory> alias, Action<IHqlExpressionFactory> predicate)
        {
            var aliasFactory = new DefaultAliasFactory(this);
            alias(aliasFactory);

            Where(aliasFactory.Current, predicate);

            return this;
        }

        internal void Where(IAlias alias, Action<IHqlExpressionFactory> predicate)
        {
            _wheres.Add(new Tuple<IAlias, Action<IHqlExpressionFactory>>(alias, predicate));
        }
    }
}
