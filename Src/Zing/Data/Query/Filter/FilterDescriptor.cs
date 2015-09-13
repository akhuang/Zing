using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query.Filter
{
    public class FilterDescriptor
    {
        public string Category { get; set; }
        public string Property { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Action<FilterContext> Filter { get; set; }
        public string Form { get; set; } 
    }
}
