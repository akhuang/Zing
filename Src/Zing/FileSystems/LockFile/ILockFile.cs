using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.FileSystems.LockFile
{
    public interface ILockFile : IDisposable
    {
        void Release();
    }
}
