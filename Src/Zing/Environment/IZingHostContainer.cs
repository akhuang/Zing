using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Environment
{
    public interface IZingHostContainer
    {
        T Resolve<T>();
    }
}
