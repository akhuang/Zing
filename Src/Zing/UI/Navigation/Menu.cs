using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Zing.UI.Navigation
{
    public class MenuItem
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Priority { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
    }
}
