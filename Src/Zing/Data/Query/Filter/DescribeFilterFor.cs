using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query.Filter
{
    public class DescribeFilterFor
    {
        private readonly string _category;

        public DescribeFilterFor(string category, string name, string description)
        {
            Types = new List<FilterDescriptor>();
            _category = category;
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<FilterDescriptor> Types { get; private set; }

        public DescribeFilterFor Element(string type, string name, string description, Action<FilterContext> filter, string form = null)
        {
            Types.Add(new FilterDescriptor { Property = type, Name = name, Description = description, Category = _category, Filter = filter, Form = form });
            return this;
        }
    }
}
