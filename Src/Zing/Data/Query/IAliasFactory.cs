using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query
{
    public interface IAliasFactory
    {
        /// <summary>
        /// Creates a join based on a property, or returns it if it already exists.
        /// </summary>
        IAliasFactory Property(string propertyName, string alias);

        /// <summary>
        /// Returns an existing alias by its name.
        /// </summary>
        IAliasFactory Named(string alias);
    }
}
