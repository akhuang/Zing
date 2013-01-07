using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Zing.Environment.Extensions.Compilers
{
    public interface IProjectFileParser
    {
        ProjectFileDescriptor Parse(string virtualPath);
        ProjectFileDescriptor Parse(Stream stream);
    }
}
