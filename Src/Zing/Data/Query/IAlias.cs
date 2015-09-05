using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query
{
    public interface IAlias
    {
        public string Name
        {
            get;
        }
    }
    public class Alias : IAlias
    {
        public Alias(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Alias can't be empty");
            }

            //Name = name.Strip('-');
            Name = name;
        }

        //public DefaultHqlQuery<IContent> Query { get; set; }
        public string Name { get; set; }
    }

    public interface IJoin : IAlias
    {
        string TableName { get; set; }
        string Type { get; set; }
        Action<IHqlExpressionFactory> WithPredicate { get; set; }
    }

    public class Join : Alias, IJoin
    {
        public Join(string tableName, string alias)
            : this(tableName, alias, "join", null) { }

        public Join(string tableName, string alias, string type)
            : this(tableName, alias, type, null)
        {
        }

        public Join(string tableName, string alias, string type, Action<IHqlExpressionFactory> withPredicate)
            : base(alias)
        {
            if (String.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException("Table Name can't be empty");
            }

            TableName = tableName;
            Type = type ?? "join";
            WithPredicate = withPredicate;
        }

        public string TableName { get; set; }
        public string Type { get; set; }
        public Action<IHqlExpressionFactory> WithPredicate { get; set; }
    }
}
