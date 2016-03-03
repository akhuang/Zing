using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Data.Query;

namespace Zing.Modules.ViewFilter
{
    class DefaultFilterFormater : IFilterCoordinator
    {
        private readonly IEnumerable<IFilterEditor> _filterEditors;

        public DefaultFilterFormater(IEnumerable<IFilterEditor> filterEditors)
        {
            _filterEditors = filterEditors;
        }

        public Action<IHqlExpressionFactory> Filter(Type type, string property, dynamic formState) 
        {
            var filterEditor = _filterEditors.FirstOrDefault(x => x.CanHandle(type));

            if (filterEditor == null)
            {
                return x => { };
            }

            return filterEditor.Filter(property, formState);
        }
    }
}
