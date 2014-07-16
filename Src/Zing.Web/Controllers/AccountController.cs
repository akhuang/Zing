using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zing.Security;
using Zing.Framework.Security;

namespace Zing.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMembershipService _membershipService;
        public AccountController(IAuthenticationService authenticationService, IMembershipService membershipService)
        {
            _authenticationService = authenticationService;
            _membershipService = membershipService;
        }
        //
        // GET: /Account/

        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(string userName, string userPwd, string returnUrl, bool rememberMe = false)
        {
            var user = ValidateLogOn(userName, userPwd);

            if (!ModelState.IsValid)
            {
                return View();
            }

            _authenticationService.SignIn(user, rememberMe);

            return new RedirectResult(returnUrl);
        }

        private IUser ValidateLogOn(string userName, string userPwd)
        {
            bool validate = true;
            if (string.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("userName", "用户名不能为空");
                validate = false;
            }

            if (string.IsNullOrEmpty(userPwd))
            {
                ModelState.AddModelError("password", "密码不能为空");
                validate = false;
            }

            if (!validate)
            {
                return null;
            }

            IUser user = _membershipService.ValidateUser(userName, userPwd);

            if (user == null)
            {
                ModelState.AddModelError("", "登录失败");
            }
            return user;
        }
    }
}
