using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zing.Modules.Users.ViewModels;
using Kendo.Mvc.Extensions;

namespace Zing.Web.Controllers
{
    public class UserController : Controller
    {
        public UserController(I)
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Customers_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetCustomers().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        private static IEnumerable<UserViewModel> GetCustomers()
        {
            IEnumerable<UserViewModel> list = new List<UserViewModel>() { 
                new UserViewModel()
                {
                    UserName="p",Email="p@p.com",NormalizedUserName="phoenix"
                },
                new UserViewModel(){UserName="p1",Email="p1@p.com",NormalizedUserName="phoenix1" }
                };

            return list;
        }
    }
}
