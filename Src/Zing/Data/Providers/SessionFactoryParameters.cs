using System.Collections.Generic;
using Zing.Environment.ShellBuilders.Models;

namespace Zing.Data.Providers {
    public class SessionFactoryParameters : DataServiceParameters {
        public IEnumerable<RecordBlueprint> RecordDescriptors { get; set; }
        public bool CreateDatabase { get; set; }
    }
}
