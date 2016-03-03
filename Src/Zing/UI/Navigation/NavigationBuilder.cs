using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Zing.UI.Navigation
{
    public class NavigationBuilder
    {
        List<MenuItem> _menus = new List<MenuItem>();

        public NavigationBuilder()
        {
        }

        public void AddMenu(string name, string actionName, string controllerName)
        {
            MenuItem menu = new MenuItem();
            menu.Name = name;

            RouteValueDictionary routeValues = new RouteValueDictionary();
            if (!string.IsNullOrEmpty(actionName))
            {
                routeValues["action"] = actionName;
            }
            if (!string.IsNullOrEmpty(controllerName))
            {
                routeValues["controller"] = controllerName;
            }
            menu.RouteValues = routeValues;

            _menus.Add(menu);
        }
        public IEnumerable<MenuItem> Build()
        {
            return _menus;
        }
    }
}
