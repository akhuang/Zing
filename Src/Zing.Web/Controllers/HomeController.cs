using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zing.Modules.Users.ViewModels;
using Zing.Framework.Security;

namespace Zing.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModel userInfo)
        {
            IMembershipService membershipService = DependencyResolver.Current.GetService<IMembershipService>();
            CreateUserParams userParas = new CreateUserParams(userInfo.NormalizedUserName, userInfo.UserName, userInfo.UserPassword, userInfo.Email);
            membershipService.CreateUser(userParas);
            return View(userInfo);
        }

    }
}
