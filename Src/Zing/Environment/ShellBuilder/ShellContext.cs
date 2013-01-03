using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Environment.ShellBuilder
{
    public class ShellContext
    {
        public ShellSettings Settings { get; set; }
        public ShellDescriptor Descriptor { get; set; }
        public ShellBlueprint Blueprint { get; set; }
        public ILifetimeScope LifetimeScope { get; set; }
        public IOrchardShell Shell { get; set; }
    }
}
