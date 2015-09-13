using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query.FilterEditors
{
    /// <summary>
    /// Coordinated all available <see cref="IFilterEditor"/> to apply specific formatting on a model binding property
    /// </summary>
    public interface IFilterCoordinator : IDependency
    {

        /// <summary>
        /// Returns the form for a specific type
        /// </summary>
        string GetForm(Type type);

        /// <summary>
        /// Returns a predicate representing the filter for a specific type
        /// </summary>
        Action<IHqlExpressionFactory> Filter(Type type, string property, dynamic formState);
         
    }
}
