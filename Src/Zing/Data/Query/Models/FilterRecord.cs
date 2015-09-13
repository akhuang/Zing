using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Data.Query.Models
{
    public class FilterRecord
    {
        public virtual int Id { get; set; }

        public virtual string Description { get; set; }
        public virtual string Category { get; set; }
        public virtual string PropertyName { get; set; }
        public virtual int Position { get; set; }
        public virtual string State { get; set; }

        // Parent property
        //public virtual FilterGroupRecord FilterGroupRecord { get; set; }
    }
}
