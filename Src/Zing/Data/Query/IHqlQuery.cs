using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query
{
    public interface IHqlQuery
    {
        int Count();

        /// <summary>
        /// Adds a where constraint to the query.
        /// </summary>
        /// <param name="alias">An expression pointing to the joined relationship.</param>
        /// <param name="predicate">A predicate expression.</param>
        IHqlQuery Where(Action<IAliasFactory> alias, Action<IHqlExpressionFactory> predicate);

        IHqlQuery Where(Action<IHqlExpressionFactory> predicate);
    }

    public interface IHqlQuery<T> : IHqlQuery where T : class
    {

    }
}
