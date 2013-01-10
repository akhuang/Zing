using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Environment.Extensions.Compilers
{
    public class CompileExtensionContext
    {
        public string VirtualPath { get; set; }
        public IAssemblyBuilder AssemblyBuilder { get; set; }
    }
}
