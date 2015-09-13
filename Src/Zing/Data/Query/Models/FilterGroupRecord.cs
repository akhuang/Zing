using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query.Models
{
    public class FilterGroupRecord
    {
        public FilterGroupRecord()
        {
            Filters = new List<FilterRecord>();
        }

        public virtual int Id { get; set; }

        //[CascadeAllDeleteOrphan, Aggregate]
        public virtual IList<FilterRecord> Filters { get; set; }

        // Parent property
        //public virtual QueryPartRecord QueryPartRecord { get; set; }
    }
}
