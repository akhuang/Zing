using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zing.Modules.Users.ViewModels;
using Kendo.Mvc.Extensions;
using Zing.Framework.Security;
using Zing.Modules.Users.Services;
using Zing.Modules.Users.Models;
using AutoMapper;
using Zing.Data;
using Zing.Modules.Data;
using System.Reflection;

namespace Zing.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IMembershipServiceInModule _membershipSer;
        private readonly ISessionFactoryHolder _sessionFactoryHolder;
        public UserController(IMembershipServiceInModule membershipService, ISessionFactoryHolder sessionFactoryHolder)
        {
            _membershipSer = membershipService;
            _sessionFactoryHolder = sessionFactoryHolder;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Customers_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetCustomers().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        private IEnumerable<UserViewModel> GetCustomers()
        {
            //IEnumerable<UserViewModel> list = new List<UserViewModel>() { 
            //    new UserViewModel()
            //    {
            //        UserName="p",Email="p@p.com",NormalizedUserName="phoenix"
            //    },
            //    new UserViewModel(){UserName="p1",Email="p1@p.com",NormalizedUserName="phoenix1" }
            //    };
            IEnumerable<UserEntity> list = _membershipSer.Fetch(null);

            IList<UserViewModel> listV = new List<UserViewModel>();
            list.ToList<UserEntity>().ForEach(x =>
            {
                listV.Add(Mapper.Map<UserEntity, UserViewModel>(x));
            });

            return listV;
        }

        public ActionResult Query()
        {
            var recordRescriptors = _sessionFactoryHolder.GetSessionFactoryParameters().RecordDescriptors;

            IEnumerable<RecordEntry> listRecordEntry = recordRescriptors.Select(x => new RecordEntry()
            {
                FullName = x.Type.FullName,
                Members = x.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => new MemberEntry()
                {
                    Member = p.Name
                }).ToList()
            });
            return View();
        }
    }
}
