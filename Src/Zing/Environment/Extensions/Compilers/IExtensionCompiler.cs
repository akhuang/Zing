using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Environment.Extensions.Compilers
{
    public interface IExtensionCompiler
    {
        void Compile(CompileExtensionContext context);
    }
}
