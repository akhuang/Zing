using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zing.UI.Navigation
{
    public interface INavigationMananger : IDependency
    {
        IEnumerable<MenuItem> BuildMenu();
    }
}
