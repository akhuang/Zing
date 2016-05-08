using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zing.Modules.Customer.Services;

namespace Zing.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _custService;
        public CustomerController(ICustomerService custService)
        {
            _custService = custService;
        }
        // GET: Customer
        public ActionResult Index()
        {
            _custService.Fetch();
            return View();
        }
    }
}