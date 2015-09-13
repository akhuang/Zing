using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query.Models
{
    public class QueryRecord
    {
        public QueryRecord()
        {
            FilterGroups = new List<FilterGroupRecord>();
        }

        public virtual IList<FilterGroupRecord> FilterGroups { get; set; }
        //public virtual IList<SortCriterionRecord> SortCriteria { get; set; }
    }
}
