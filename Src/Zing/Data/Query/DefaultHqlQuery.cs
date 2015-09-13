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

        public string TableName
        {
            get;
            private set;
        }

        public string FromAliasName
        {
            get;
            private set;
        }

        public DefaultHqlQuery(string tableName, string fromAliasName, ISession session)
        {
            this.TableName = tableName;
            this.FromAliasName = fromAliasName;
            this._session = session;
        }
        public int Count()
        {
            return Convert.ToInt32(_session.CreateQuery(ToHql())
                          .SetCacheable(true)
                          .UniqueResult())
               ;
        }

        public string ToHql()
        {
            var sb = new StringBuilder();

            sb.Append("select count(1) ").AppendLine();
            sb.Append("from ").Append(_from.TableName).Append(" as ").Append(_from.Name).AppendLine();

            if (_wheres.Any())
            {
                sb.Append("where ");

                var expressions = new List<string>();

                foreach (var where in _wheres)
                {
                    var expressionFactory = new DefaultHqlExpressionFactory();
                    where.Item2(expressionFactory);
                    expressions.Add(expressionFactory.Criterion.ToHql(where.Item1));
                }

                sb.Append("(").Append(String.Join(") AND (", expressions.ToArray())).Append(")").AppendLine();
            }

            return sb.ToString();
        }

        internal IAlias BindFromPath()
        {
            if (_from == null)
            {
                _from = new Join(TableName, FromAliasName);
            }

            return _from;
        }
        public IHqlQuery Where(Action<IHqlExpressionFactory> predicate)
        {
            Where(_from, predicate);
            return this;
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
