using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Data.Query.Filter;
using Zing.Data.Query.Models;

namespace Zing.Data.Query.Services
{
    public class HqlQueryManager : IHqlQueryManager
    {
        private readonly IEnumerable<IFilterProvider> _filterProviders;

        public HqlQueryManager(IEnumerable<IFilterProvider> filterProvider)
        {
            _filterProviders = filterProvider;
        }

        private IEnumerable<FilterDescriptor> DescribeFilters()
        {
            var context = new DescribeFilterContext();

            foreach (var provider in _filterProviders)
            {
                provider.Describe(context);
            }

            return context.Describe();
        }

        public void GetQuery(IHqlQuery query, QueryRecord queryRecord)
        {
            var availableFilters = DescribeFilters().ToList();

            foreach (var group in queryRecord.FilterGroups)
            {
                foreach (var filter in group.Filters)
                {
                    var filterContext = new FilterContext()
                    {
                        Query = query,
                        State = JsonConvert.DeserializeObject(filter.State)
                    };

                    string category = filter.Category;
                    string property = filter.PropertyName;

                    var descriptor = availableFilters.FirstOrDefault(x => x.Category == category && x.Property == property);

                    if (descriptor == null)
                    {
                        continue;
                    }

                    descriptor.Filter(filterContext);
                }
            }
        }
    }
}
