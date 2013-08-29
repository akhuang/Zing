using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zing.Modules.Users.ViewModels;
using Zing.Framework.Security;
using Zing.Logging;

namespace Zing.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ILogger Logger { get; set; }

        public HomeController()
        {
            Logger = NullLogger.Instance;
        }

        public ActionResult Index()
        {
            Logger.Debug("Index");
            ViewData["aaaa"] = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="ddd",Value="2" },
                new SelectListItem(){ Text="cc",Value="1" }
            };
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModel userInfo)
        {
            IMembershipService membershipService = DependencyResolver.Current.GetService<IMembershipService>();
            CreateUserParams userParas = new CreateUserParams(userInfo.NormalizedUserName, userInfo.UserName, userInfo.UserPassword, userInfo.Email);
            membershipService.CreateUser(userParas);

            ViewData["aaaa"] = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="ddd",Value="2" },
                new SelectListItem(){ Text="cc",Value="1" }
            };
            return View(userInfo);
        }

    }
}
