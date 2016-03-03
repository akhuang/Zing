using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zing.Modules.Order.Models;
using Zing.Modules.Order.Services;

namespace Zing.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int? id)
        {
            OrderEntity order = new OrderEntity();
            order.Name = "Order";
            order.AddOrderDetail(new OrderDetailEntity()
            {
                Name = "OrderDetail"
            });

            _orderService.Create(order);

            TempData["msg"] = "success";
            return View();
        }
    }
}