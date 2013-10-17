using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zing.Modules.Users.Models;
using Zing.UI;
using Zing.Modules.Users.Services;
using Zing.UI.Navigation;

namespace Zing.Web.Controllers
{
    public class PagerController : Controller
    {
        private IList<UserEntity> allUsers = new List<UserEntity>();

        public PagerController()
        {
            InitializeProducts();
        }
        //
        // GET: /Pager/

        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            IMembershipServiceInModule membershipService = DependencyResolver.Current.GetService<IMembershipServiceInModule>();
            Pagination pagination = new Pagination(currentPageIndex);
            var allUsers = membershipService.Fetch(null, null, pagination);

            return View(allUsers.ToPagedList(currentPageIndex, 5, 10));
        }

        private void InitializeProducts()
        {
            // Create a list of products. 50% of them are in the Shoes category, 25% in the Electronics 
            // category and 25% in the Food category.
            for (var i = 0; i < 527; i++)
            {
                var product = new UserEntity();
                product.NormalizedUserName = "Product " + (i + 1);
                var categoryIndex = i % 4;
                if (categoryIndex > 2)
                {
                    categoryIndex = categoryIndex - 3;
                }
                //product.Category = allCategories[categoryIndex];
                allUsers.Add(product);
            }
        }

    }
}
