using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Configuration;
using Zing.Environment.Descriptor.Models;
using Zing.Environment.Extensions.Models;

namespace Zing.Environment.ShellBuilder.Models
{
    public class ShellBlueprint
    {
        public ShellSettings Settings { get; set; }
        public ShellDescriptor Descriptor { get; set; }

        public IEnumerable<DependencyBlueprint> Dependencies { get; set; }

        public IEnumerable<RecordBlueprint> Records { get; set; }
    }
    public class DependencyBlueprint : ShellBlueprintItem
    {
        public IEnumerable<ShellParameter> Parameters { get; set; }
    }
    public class ShellBlueprintItem
    {
        public Type Type { get; set; }
        public Feature Feature { get; set; }
    }
    public class RecordBlueprint : ShellBlueprintItem
    {
        public string TableName { get; set; }
    }
}
