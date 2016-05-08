using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zing.UI.Navigation;

namespace Zing.Modules.Contract
{
    public class Menu : INavigationProvider
    {
        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add("合同管理", "20", x => x.Action("Index", "Contract"));
        }
    }
}
