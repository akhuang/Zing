using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zing.UI.Navigation
{
    public class NavigationManager : INavigationMananger
    {
        private IEnumerable<INavigationProvider> _providers;
        public NavigationManager(IEnumerable<INavigationProvider> providers)
        {
            _providers = providers;
        }

        public IEnumerable<MenuItem> BuildMenu()
        {
            return GetSources().SelectMany(x => x).OrderBy(x => x.Priority);

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
