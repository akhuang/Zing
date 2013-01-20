using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Zing.Mvc
{
    /// <summary>
    /// This interface ensures all base view pages implement the 
    /// same set of additional members
    /// </summary>
    public interface IZingViewPage
    {
        WorkContext WorkContext { get; }
    }
}
