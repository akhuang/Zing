using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zing.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon()
        {

        }
    }
}
