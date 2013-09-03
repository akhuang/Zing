using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zing.Modules.Users.ViewModels;
using Zing.Framework.Security;
using Zing.Logging;
using Zing.Modules.Users.Services;
using Zing.Modules.Users.Models;
using Zing.Mvc;

namespace Zing.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ILogger Logger { get; set; }

        private readonly IMembershipService _membershipService;
        private readonly IMembershipServiceInModule _membershipServiceInModule;

        public HomeController(IMembershipService membershipService, IMembershipServiceInModule membershipServiceInModule)
        {
            Logger = NullLogger.Instance;
            _membershipService = membershipService;
            _membershipServiceInModule = membershipServiceInModule;
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

        [AutoMap(typeof(UserEntity), typeof(UserViewModel))]
        public ActionResult Edit(int id)
        {
            ViewData["aaaa"] = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="ddd",Value="2" },
                new SelectListItem(){ Text="cc",Value="1" }
            };

            UserEntity model = _membershipServiceInModule.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userInfo)
        {
            //_membershipServiceInModule.Update(userInfo);
            return View();
        }
    }
}
