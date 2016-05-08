using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Zing.UI.Navigation
{
    public class NavigationManager : INavigationMananger
    {
        private IEnumerable<INavigationProvider> _providers;
        private UrlHelper _urlHelper;
        public NavigationManager(IEnumerable<INavigationProvider> providers,
            UrlHelper urlHelper)
        {
            _providers = providers;
            _urlHelper = urlHelper;
        }

        public IEnumerable<MenuItem> BuildMenu()
        {
            return FinishMenu(GetSources().SelectMany(x => x).OrderBy(x => x.Position).ToArray());
        }

        private IEnumerable<MenuItem> FinishMenu(ICollection<MenuItem> menuItems)
        {
            foreach (var item in menuItems)
            {
                item.Href = _urlHelper.RouteUrl(item.RouteValues);
            }

            return menuItems;
        }

        private IEnumerable<IEnumerable<MenuItem>> GetSources()
        {
            foreach (var provider in _providers)
            {
                IEnumerable<MenuItem> items;
                NavigationBuilder builder = new NavigationBuilder();
                provider.GetNavigation(builder);
                items = builder.Build();

                yield return items;
            }
        }
    }
}
