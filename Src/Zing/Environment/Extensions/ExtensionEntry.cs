using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Environment.Extensions.Models;
using System.Reflection;

namespace Zing.Environment.Extensions
{
    public class ExtensionEntry
    {
        public ExtensionDescriptor Descriptor { get; set; }
        public Assembly Assembly { get; set; }
        public IEnumerable<Type> ExportedTypes { get; set; }
    }
}
