using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Modules.Data
{
    public class RecordEntry
    {
        public string FullName { get; set; }
        public IList<MemberEntry> Members { get; set; }
    }

    public class MemberEntry
    {
        public string Member { get; set; }
    }
}
