using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing.UI.Navigation;

namespace Zing.Modules.Order
{
    public class Menu : INavigationProvider
    {
        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add("订单管理", "10", x => x.Action("Index", "Order"));
        }
    }
}
