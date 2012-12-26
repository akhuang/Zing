using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Mvc
{
    public interface IZingViewPage
    {
        WorkContext WorkContext { get; }
        void SetMeta(string name, string content);
    }
}
