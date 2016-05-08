using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing.UI.Navigation;

namespace Zing.Modules.Customer
{
    public class Menu : INavigationProvider
    {
        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add("客户管理", "10", x => x.Action("Index", "Customer"));
        }
    }
}
