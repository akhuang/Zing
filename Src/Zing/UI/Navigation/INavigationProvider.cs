using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zing.UI.Navigation
{
    public interface INavigationProvider
    {
        void GetNavigation(NavigationBuilder builder);
    }
}
